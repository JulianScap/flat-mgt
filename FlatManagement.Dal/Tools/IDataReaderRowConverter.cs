using System.Data.SqlClient;

namespace FlatManagement.Dal.Tools
{
	public interface IDataReaderRowConverter
	{
		object Convert(SqlDataReader sqlDataReader);
	}
}