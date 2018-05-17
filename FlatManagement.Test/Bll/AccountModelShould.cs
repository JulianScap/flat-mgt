using FlatManagement.Bll.Interface;
using FlatManagement.Common.Services;
using FlatManagement.Test.Tools;
using Xunit;

namespace FlatManagement.Test.Bll
{
	public class AccountModelShould : TestBase
	{
		[Fact]
		public void ReturnAValidAccountByLogin()
		{
			IAccountModel iam = ServiceLocator.Instance.GetService<IAccountModel>();
			iam.GetByLogin(login: "test");

			Assert.NotEmpty(iam);
		}
	}
}
