using FlatManagement.Bll;
using FlatManagement.Bll.Interface;
using Xunit;

namespace FlatManagement.Dal.Test
{
	public class BllTest
	{
		[Fact]
		public void Test1()
		{
			IPeriodTypeModel ptm = BllFactory.Instance.Get<IPeriodTypeModel>();
			//ptm.GetAll();
		}
	}
}
