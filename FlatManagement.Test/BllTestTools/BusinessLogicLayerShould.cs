using FlatManagement.Bll;
using FlatManagement.Bll.Interface;
using Xunit;

namespace FlatManagement.Test.BllTestTools
{
	public class BusinessLogicLayerShould
	{
		[Fact]
		public void Test1()
		{
			IPeriodTypeModel ptm = BllFactory.Instance.Get<IPeriodTypeModel>();
			ptm.GetAll();
		}
	}
}
