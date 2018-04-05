using FlatManagement.Dal.Impl;
using FlatManagement.Dal.Interface;
using Xunit;

namespace FlatManagement.Dal.Test
{
	public class UnitTest1
	{
		[Fact]
		public void Test1()
		{
			IPeriodTypeDataAccess da = DalFactory.Instance.Get<IPeriodTypeDataAccess>();
			da.GetAll();
		}
	}
}
