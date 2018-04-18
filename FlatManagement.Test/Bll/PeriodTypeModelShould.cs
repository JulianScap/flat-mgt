using FlatManagement.Bll.Impl;
using FlatManagement.Bll.Interface;
using FlatManagement.Common.Services;
using FlatManagement.Test.Tools;
using Xunit;

namespace FlatManagement.Test.Bll
{
	public class PeriodTypeModelShould : TestBase
	{
		[Fact]
		public void ReturnAValidModelObject()
		{
			ServiceLocator.Instance.SetConfiguration(GetConfiguration());
			IPeriodTypeModel ptm = ServiceLocator.Instance.GetService<IPeriodTypeModel>();

			Assert.NotNull(ptm);
			Assert.IsType<PeriodTypeModel>(ptm);
		}
	}
}
