using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using FlatManagement.Common.Dto;
using FlatManagement.Common.Extensions;
using FlatManagement.Common.Logging;
using FlatManagement.Dal.Interface;

namespace FlatManagement.Dal.Impl
{
	public abstract class AbstractDataAccess : IDataAccess
	{

	}

	public abstract class AbstractDataAccess<TList, TDto> : AbstractDataAccess, IDataAccess<TList>
		where TDto : new()
		where TList : AbstractDtoList<TDto>, new()
	{
		private static readonly string tListTypeName;

		static AbstractDataAccess()
		{
			tListTypeName = typeof(TList).Name;
		}

		public TList GetAll()
		{
			return GetMany(OperationEnum.GetAll);
		}

		protected virtual TList GetMany(OperationEnum operation, string methodName = null)
		{
			TList result = new TList();

			using (ConnectionInfoContainer cic = GetConnectionInfoContainer(operation, methodName))
			{
				Fill(result, cic.Reader);
			}

			return result;
		}

		protected ConnectionInfoContainer GetConnectionInfoContainer(OperationEnum operation, string methodName = null)
		{
			ConnectionInfoContainer result = new ConnectionInfoContainer();

			string procedureName = GetStoredProcedureName(operation, methodName);

			try
			{
				result.Connection = GetConnection();
				result.Command = GetStoredProcedureCommand(procedureName, result.Connection);
				result.Connection.Open();
				result.Reader = result.Command.ExecuteReader();
				return result;
			}
			catch (Exception ex)
			{
				LogStuff.Log(ex);
				result.SafeDispose();
				throw;
			}
		}

		protected virtual bool Fill(TList list, SqlDataReader reader, int? count = null)
		{
			bool lastReadResult = false;
			int recordsProcessed = 0;
			int recordsMax = count ?? Int32.MaxValue;

			lastReadResult = reader.Read();

			while (lastReadResult && recordsProcessed < recordsMax)
			{
				list.New();
				for (int i = 0; i < reader.FieldCount; i++)
				{
					AssignIfNeeded(list, reader, i);
				}

				recordsProcessed += 1;

				lastReadResult = reader.Read();
			}

			return lastReadResult;
		}

		protected virtual void AssignIfNeeded(TList list, SqlDataReader reader, int index)
		{
			if (!reader.IsDBNull(index))
			{
				object value = reader.GetValue(index);
				string columnName = reader.GetName(index);
				PropertyInfo pi = typeof(TList).GetProperty(columnName);
				pi.SetValue(list, value);
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
	}
}
