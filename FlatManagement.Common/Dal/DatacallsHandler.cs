using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using FlatManagement.Common.Dto;
using FlatManagement.Common.Exceptions;
using FlatManagement.Common.Extensions;
using FlatManagement.Common.WebApi;
using Microsoft.Extensions.Configuration;

namespace FlatManagement.Common.Dal
{
	public class DatacallsHandler : IDatacallsHandler
	{
		private readonly string connectionString;
		private readonly IUserInfoProvider userInfoProvider;

		public DatacallsHandler(IConfiguration configuration, IUserInfoProvider userInfoProvider)
		{
			this.userInfoProvider = userInfoProvider;
			this.connectionString = configuration["Database:ConnectionString"];
		}

		public IEnumerable GetMany(string command, Parameter[] parameters, IDataReaderRowConverter converter)
		{
			SqlConnection sqlConnection = null;
			SqlCommand sqlCommand = null;
			SqlDataReader sqlDataReader = null;
			IList result = new ArrayList();

			try
			{
				sqlConnection = new SqlConnection(connectionString);
				sqlCommand = new SqlCommand(command, sqlConnection) { CommandType = CommandType.StoredProcedure };
				SetParameters(sqlCommand, parameters);
				SetUserInfoParameter(sqlCommand);
				sqlConnection.Open();
				sqlDataReader = sqlCommand.ExecuteReader();

				while (sqlDataReader.Read())
				{
					result.Add(converter.Convert(sqlDataReader));
				}
			}
			finally
			{
				sqlDataReader.SafeDispose();
				sqlCommand.SafeDispose();
				sqlConnection.SafeDispose();
			}

			return result;
		}

		public bool GetBool(string command, Parameter[] parameters)
		{
			SqlConnection sqlConnection = null;
			SqlCommand sqlCommand = null;
			SqlDataReader sqlDataReader = null;
			bool result = false;

			try
			{
				sqlConnection = new SqlConnection(connectionString);
				sqlCommand = new SqlCommand(command, sqlConnection) { CommandType = CommandType.StoredProcedure };
				SetParameters(sqlCommand, parameters);
				SetUserInfoParameter(sqlCommand);
				SqlParameter returnValue = AddReturnParameter(sqlCommand);
				sqlConnection.Open();
				sqlCommand.ExecuteNonQuery();
				result = (bool)returnValue.Value;
			}
			finally
			{
				sqlDataReader.SafeDispose();
				sqlCommand.SafeDispose();
				sqlConnection.SafeDispose();
			}

			return result;
		}

		private SqlParameter AddReturnParameter(SqlCommand sqlCommand)
		{
			SqlParameter parameter = sqlCommand.CreateParameter();

			parameter.Direction = ParameterDirection.ReturnValue;
			parameter.DbType = DbType.Boolean;
			sqlCommand.Parameters.Add(parameter);

			return parameter;
		}

		public object GetOne(string command, Parameter[] parameters, IDataReaderRowConverter converter, bool throwIfMultipleResultFound = false)
		{
			SqlConnection sqlConnection = null;
			SqlCommand sqlCommand = null;
			SqlDataReader sqlDataReader = null;
			object result = null;

			try
			{
				sqlConnection = new SqlConnection(connectionString);
				sqlCommand = new SqlCommand(command, sqlConnection) { CommandType = CommandType.StoredProcedure };
				SetParameters(sqlCommand, parameters);
				SetUserInfoParameter(sqlCommand);
				sqlConnection.Open();
				sqlDataReader = sqlCommand.ExecuteReader();

				if (sqlDataReader.Read())
				{
					result = converter.Convert(sqlDataReader);
				}

				if (throwIfMultipleResultFound && sqlDataReader.Read())
				{
					throw new TooManyResultFoundException($"More than one row was returned when calling {command}");
				}
			}
			finally
			{
				sqlDataReader.SafeDispose();
				sqlCommand.SafeDispose();
				sqlConnection.SafeDispose();
			}

			return result;
		}

		public int Execute(string command, Parameter[] parameters, Parameter[] outParameters)
		{
			SqlConnection sqlConnection = null;
			SqlCommand sqlCommand = null;
			int result = 0;

			try
			{
				sqlConnection = new SqlConnection(connectionString);
				sqlCommand = new SqlCommand(command, sqlConnection) { CommandType = CommandType.StoredProcedure };

				SetParameters(sqlCommand, parameters);
				SetUserInfoParameter(sqlCommand);
				SetOutParameters(sqlCommand, outParameters);

				sqlConnection.Open();
				result = sqlCommand.ExecuteNonQuery();
				PopulateOutParametersValues(sqlCommand, outParameters);
			}
			finally
			{
				sqlCommand.SafeDispose();
				sqlConnection.SafeDispose();
			}

			return result;
		}

		public int Execute(string command, Parameter[] parameters)
		{
			SqlConnection sqlConnection = null;
			SqlCommand sqlCommand = null;
			int result = 0;

			try
			{
				sqlConnection = new SqlConnection(connectionString);
				sqlCommand = new SqlCommand(command, sqlConnection) { CommandType = CommandType.StoredProcedure };
				SetParameters(sqlCommand, parameters);
				SetUserInfoParameter(sqlCommand);
				sqlConnection.Open();
				result = sqlCommand.ExecuteNonQuery();
			}
			finally
			{
				sqlCommand.SafeDispose();
				sqlConnection.SafeDispose();
			}

			return result;
		}

		private void SetParameters(SqlCommand sqlCommand, Parameter[] parameters)
		{
			if (parameters != null)
			{
				foreach (Parameter parameter in parameters)
				{
					SqlParameter sqlParameter = sqlCommand.CreateParameter();
					sqlParameter.Direction = ParameterDirection.Input;
					sqlParameter.ParameterName = parameter.Name;
					sqlParameter.SqlDbType = GetAsSqlDbType(parameter.Type);
					if (parameter.Value == null)
					{
						sqlParameter.SqlValue = DBNull.Value;
					}
					else
					{
						sqlParameter.Value = parameter.Value;
					}

					sqlCommand.Parameters.Add(sqlParameter);

				}
			}
		}

		private void SetUserInfoParameter(SqlCommand sqlCommand)
		{
			SqlParameter sqlParameter = sqlCommand.CreateParameter();
			sqlParameter.Direction = ParameterDirection.Input;
			sqlParameter.ParameterName = "UserLogin";
			sqlParameter.SqlDbType = SqlDbType.NVarChar;
			UserInfo userInfo = userInfoProvider.GetUserInfo();
			if (userInfo == null)
			{
				sqlParameter.SqlValue = DBNull.Value;
			}
			else
			{
				sqlParameter.Value = userInfo.Login;
			}
			sqlCommand.Parameters.Add(sqlParameter);
		}

		private void SetOutParameters(SqlCommand sqlCommand, Parameter[] parameters)
		{
			foreach (Parameter parameter in parameters)
			{
				SqlParameter sqlParameter = sqlCommand.CreateParameter();
				sqlParameter.Direction = ParameterDirection.Output;
				sqlParameter.ParameterName = parameter.Name;
				sqlParameter.SqlDbType = GetAsSqlDbType(parameter.Type);
				sqlCommand.Parameters.Add(sqlParameter);
			}
		}

		private SqlDbType GetAsSqlDbType(TypeEnum type)
		{
			switch (type)
			{
				case TypeEnum.Int32:
					return SqlDbType.Int;
				case TypeEnum.Int64:
					return SqlDbType.BigInt;
				case TypeEnum.String:
					return SqlDbType.NVarChar;
				case TypeEnum.Guid:
					return SqlDbType.UniqueIdentifier;
				case TypeEnum.Date:
					return SqlDbType.Date;
				case TypeEnum.Time:
					return SqlDbType.Time;
				case TypeEnum.DateTime:
					return SqlDbType.DateTime;
				case TypeEnum.DateTimeOffset:
					return SqlDbType.DateTimeOffset;
				case TypeEnum.Boolean:
					return SqlDbType.Bit;
				default:
					return SqlDbType.Int;
			}
		}

		private void PopulateOutParametersValues(SqlCommand sqlCommand, Parameter[] outParameters)
		{
			foreach (Parameter parameter in outParameters)
			{
				SqlParameter sqlParameter = sqlCommand.Parameters[parameter.Name];
				parameter.Value = sqlParameter.Value;
			}
		}
	}
}
