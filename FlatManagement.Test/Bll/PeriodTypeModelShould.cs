using FlatManagement.Bll;
using FlatManagement.Bll.Impl;
using FlatManagement.Bll.Interface;
using Xunit;

namespace FlatManagement.Test.Bll
{
	public class PeriodTypeModelShould
	{
		[Fact]
		public void ReturnAValidModelObject()
		{
			IPeriodTypeModel ptm = BllFactory.Instance.Get<IPeriodTypeModel>();

			Assert.NotNull(ptm);
			Assert.IsType<PeriodTypeModel>(ptm);
		}
	}
}
