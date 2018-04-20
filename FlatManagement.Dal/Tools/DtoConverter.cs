using System.Collections.Concurrent;
using System.Data.SqlClient;
using System.Reflection;

namespace FlatManagement.Dal.Tools
{
	internal class DtoConverter<TDto> : IDataReaderRowConverter
		where TDto : new()
	{
		private static readonly ConcurrentDictionary<string, PropertyInfo> properties;

		static DtoConverter()
		{
			properties = new ConcurrentDictionary<string, PropertyInfo>();
		}

		public object Convert(SqlDataReader sqlDataReader)
		{
			TDto newItem = new TDto();

			for (int i = 0; i < sqlDataReader.FieldCount; i++)
			{
				Assign(newItem, sqlDataReader, i);
			}

			return newItem;
		}


		protected static void Assign(TDto item, SqlDataReader reader, int index)
		{
			if (!reader.IsDBNull(index))
			{
				object value = reader.GetValue(index);
				string columnName = reader.GetName(index);
				PropertyInfo pi = GetProperty(columnName);
				pi.SetValue(item, value);
			}
		}

		private static PropertyInfo GetProperty(string columnName)
		{
			PropertyInfo result = null;

			if (!properties.TryGetValue(columnName, out result))
			{
				result = typeof(TDto).GetProperty(columnName);
				properties.TryAdd(columnName, result);
			}

			return result;
		}
	}
}