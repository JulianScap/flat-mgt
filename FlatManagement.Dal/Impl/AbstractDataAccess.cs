using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using FlatManagement.Common.Dto;
using FlatManagement.Common.Exceptions;
using FlatManagement.Common.Extensions;
using FlatManagement.Common.Logging;
using FlatManagement.Dal.Interface;
using Microsoft.Extensions.Configuration;

namespace FlatManagement.Dal.Impl
{
	public abstract class AbstractDataAccess<TDto> : IDataAccess<TDto>
		where TDto : IDto, new()
	{
		private const string IdFieldName = "new_id";
		private static readonly string tListTypeName;
		private static readonly ConcurrentDictionary<string, PropertyInfo> properties;
		private IConfiguration configuration;

		static AbstractDataAccess()
		{
			tListTypeName = typeof(TDto).Name;
			properties = new ConcurrentDictionary<string, PropertyInfo>();
		}

		protected AbstractDataAccess(IConfiguration configuration)
		{
			this.configuration = configuration;
		}

		public IEnumerable<TDto> GetAll()
		{
			return GetMany(OperationEnum.GetAll);
		}

		protected virtual IEnumerable<TDto> GetMany(OperationEnum operation, string methodName = null)
		{
			List<TDto> result = new List<TDto>();

			using (ConnectionInfoContainer cic = GetConnectionInfoContainer(operation, methodName))
			{
				cic.Connection.Open();
				cic.Reader = cic.Command.ExecuteReader();
				Fill(result, cic.Reader);
			}

			return result;
		}

		protected virtual TDto GetSingle(OperationEnum operation, Parameter[] parameters, string methodName = null)
		{
			List<TDto> result = new List<TDto>();

			using (ConnectionInfoContainer cic = GetConnectionInfoContainer(operation, methodName))
			{
				AddParameters(cic, parameters);
				cic.Connection.Open();
				cic.Reader = cic.Command.ExecuteReader();
				Fill(result, cic.Reader);
			}

			return result.Single();
		}

		protected virtual int Insert(OperationEnum operation, Parameter[] parameters, string methodName = null)
		{
			using (ConnectionInfoContainer cic = GetConnectionInfoContainer(operation, methodName))
			{
				AddParameters(cic, parameters);
				AddNewIdParameter(cic);
				cic.Connection.Open();
				cic.Command.ExecuteScalar();
				return (int)cic.Command.Parameters[IdFieldName].Value;
			}
		}

		protected virtual void Update(OperationEnum operation, Parameter[] parameters, string methodName = null)
		{
			using (ConnectionInfoContainer cic = GetConnectionInfoContainer(operation, methodName))
			{
				AddParameters(cic, parameters);
				cic.Connection.Open();
				cic.Command.ExecuteScalar();
			}
		}

		private void AddNewIdParameter(ConnectionInfoContainer cic)
		{
			SqlParameter parameter = cic.Command.Parameters.Add(IdFieldName, SqlDbType.Int);
			parameter.Direction = ParameterDirection.Output;
		}

		private void AddParameters(ConnectionInfoContainer cic, Parameter[] parameters)
		{
			foreach (Parameter parameter in parameters)
			{
				cic.Command.Parameters.AddWithValue(parameter.FieldName, parameter.Value);
			}
		}

		protected ConnectionInfoContainer GetConnectionInfoContainer(OperationEnum operation, string methodName = null)
		{
			ConnectionInfoContainer result = new ConnectionInfoContainer();

			string procedureName = GetStoredProcedureName(operation, methodName);

			try
			{
				result.Connection = GetConnection();
				result.Command = GetStoredProcedureCommand(procedureName, result.Connection);
				return result;
			}
			catch (Exception ex)
			{
				LogStuff.Log(ex);
				result.SafeDispose();
				throw;
			}
		}

		protected virtual bool Fill(List<TDto> list, SqlDataReader reader, int? count = null)
		{
			bool lastReadResult = false;
			int recordsProcessed = 0;
			int recordsMax = count ?? Int32.MaxValue;

			lastReadResult = reader.Read();

			while (lastReadResult && recordsProcessed < recordsMax)
			{
				TDto newItem = new TDto();
				for (int i = 0; i < reader.FieldCount; i++)
				{
					AssignIfNeeded(newItem, reader, i);
				}

				list.Add(newItem);
				recordsProcessed += 1;

				lastReadResult = reader.Read();
			}

			return lastReadResult;
		}

		protected virtual void AssignIfNeeded(TDto item, SqlDataReader reader, int index)
		{
			if (!reader.IsDBNull(index))
			{
				object value = reader.GetValue(index);
				string columnName = reader.GetName(index);
				PropertyInfo pi = GetProperty(columnName);
				pi.SetValue(item, value);
			}
		}

		private PropertyInfo GetProperty(string columnName)
		{
			PropertyInfo result = null;

			if (!properties.TryGetValue(columnName, out result))
			{
				result = typeof(TDto).GetProperty(columnName);
				properties.TryAdd(columnName, result);
			}

			return result;
		}

		protected virtual SqlCommand GetStoredProcedureCommand(string procedureName, SqlConnection connection)
		{
			return new SqlCommand(procedureName, connection)
			{
				CommandType = CommandType.StoredProcedure
			};
		}

		protected virtual string GetStoredProcedureName(OperationEnum operation, string name = null)
		{
			if (operation == OperationEnum.Custom)
			{
				return tListTypeName + "_Custom_" + name;
			}
			else
			{
				return tListTypeName + "_" + operation.ToString();
			}
		}

		protected virtual SqlConnection GetConnection()
		{
			return new SqlConnection(configuration["Database:ConnectionString"]);
		}

		public TDto GetById(params object[] ids)
		{
			string[] idPropertyNames = new TDto().IdFieldNames;
			Parameter[] parameters = BuildIdParameters(idPropertyNames, ids);
			return GetSingle(OperationEnum.GetById, parameters);
		}

		private Parameter[] BuildIdParameters(string[] idPropertyNames, object[] ids)
		{
			if (idPropertyNames.Length != ids.Length)
			{
				throw new InvalidIdException("Incorrect number of ID parameter provided");
			}

			Parameter[] result = new Parameter[idPropertyNames.Length];

			for (int i = 0; i < result.Length; i++)
			{
				result[i] = new Parameter(idPropertyNames[i], ids[i]);
			}

			return result;
		}

		public void Update(TDto item)
		{
			const bool update = true;
			Parameter[] parameters = BuildParametersFromDto(item, update);
			Update(OperationEnum.Update, parameters);
		}

		private Parameter[] BuildParametersFromDto(TDto item, bool update)
		{
			string[] propertiesToSave = item.FieldNames;

			if (update)
			{
				propertiesToSave = propertiesToSave.Merge(item.IdFieldNames).ToArray();
			}

			Parameter[] result = new Parameter[propertiesToSave.Length];

			for (int i = 0; i < result.Length; i++)
			{
				PropertyInfo pi = GetProperty(propertiesToSave[i]);
				object value = pi.GetValue(item);

				result[i] = new Parameter(propertiesToSave[i], value);
			}

			return result;
		}
	}
}
