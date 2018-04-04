using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using FlatManagement.Common.Dto;
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
			return GetMany(Operation.GetAll);
		}

		protected virtual TList GetMany(Operation operation, string methodName = null)
		{
			TList result = new TList();

			string procedureName = GetStoredProcedureName(operation, methodName);
			using (SqlConnection connection = GetConnection())
			using (SqlCommand command = GetStoredProcedureCommand(procedureName, connection))
			{
				connection.Open();
				SetPagingParameters(command);
				using (SqlDataReader reader = command.ExecuteReader())
				{
					Fill(result, reader);
				}
			}

			return result;
		}

		protected virtual void Fill(TList list, SqlDataReader reader)
		{
			while (reader.Read())
			{
				list.New();
				for (int i = 0; i < reader.FieldCount; i++)
				{
					AssignIfNeeded(list, reader, i);
				}
			}
		}

		private void AssignIfNeeded(TList list, SqlDataReader reader, int index)
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

		protected virtual void SetPagingParameters(SqlCommand command)
		{
			// TODO si j'ai pas la flemme
		}

		protected virtual string GetStoredProcedureName(Operation operation, string name)
		{
			if (operation == Operation.Custom)
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

	public enum Operation
	{
		GetAll,
		Custom,
	}
}
