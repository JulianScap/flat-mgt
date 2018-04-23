using System.Data.SqlClient;

namespace FlatManagement.Common.Dal
{
	public interface IDataReaderRowConverter
	{
		object Convert(SqlDataReader sqlDataReader);
	}
}