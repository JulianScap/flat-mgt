using FlatManagement.Bll.Interface;
using FlatManagement.Common.Services;
using FlatManagement.Common.WebApi;
using FlatManagement.Test.Tools;
using Xunit;

namespace FlatManagement.Test.Bll
{
	public class FlatmateModelShould : TestBase
	{
		[Fact]
		public void ReturnAValidAccountByLogin()
		{
			IFlatmateModel fm = ServiceLocator.Instance.GetService<IFlatmateModel>();

			fm.GetForUser();

			Assert.NotEmpty(fm);
		}
	}
}
