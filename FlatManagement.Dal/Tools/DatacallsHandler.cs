using System.Collections;
using System.Data;
using System.Data.SqlClient;
using FlatManagement.Common.Exceptions;
using FlatManagement.Common.Extensions;
using Microsoft.Extensions.Configuration;

namespace FlatManagement.Dal.Tools
{
	public class DatacallsHandler
	{
		private readonly string connectionString;

		public DatacallsHandler(IConfiguration configuration)
			: this(configuration["Database:ConnectionString"])
		{
		}

		public DatacallsHandler(string connectionString)
		{
			this.connectionString = connectionString;
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
					sqlCommand.Parameters.AddWithValue(parameter.FieldName, parameter.Value);
				}
			}
		}
	}
}
