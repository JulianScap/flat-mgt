using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using FlatManagement.Common.Dto.Attributes;
using FlatManagement.Common.Exceptions;
using FlatManagement.Common.Extensions;
using FlatManagement.Common.Logging;
using FlatManagement.Dal.Interface;

namespace FlatManagement.Dal.Impl
{
	public abstract class AbstractDataAccess<TDto> : IDataAccess<TDto>
		where TDto : new()
	{
		private static readonly string tListTypeName;

		static AbstractDataAccess()
		{
			tListTypeName = typeof(TDto).Name;
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

			return result.First();
		}

		private void AddParameters(ConnectionInfoContainer cic, Parameter[] parameters)
		{
			foreach (var parameter in parameters)
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
				PropertyInfo pi = typeof(TDto).GetProperty(columnName);
				pi.SetValue(item, value);
			}
		}

		protected virtual SqlCommand GetStoredProcedureCommand(string procedureName, SqlConnection connection)
		{
			return new SqlCommand(procedureName, connection)
			{
				CommandType = CommandType.StoredProcedure
			};
		}

		protected virtual string GetStoredProcedureName(OperationEnum operation, string name)
		{
			if (operation == OperationEnum.Custom)
			{
				return tListTypeName + "_" + name;
			}
			else
			{
				return tListTypeName + "_" + operation.ToString();
			}
		}

		protected virtual SqlConnection GetConnection()
		{
			return new SqlConnection("Server=(local);Database=FlatManagement;User Id=fm_user;Password=fm_user;");
		}

		public TDto GetById(params object[] ids)
		{
			Type tdtoType = typeof(TDto);
			return GetById(tdtoType, ids);
		}

		private TDto GetById(Type tdtoType, params object[] ids)
		{
			string[] idPropertyNames = IdPropertyNameAttribute.GetIdPropertyName(tdtoType);
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
	}
}
