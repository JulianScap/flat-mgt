using FlatManagement.Bll.Interface;
using FlatManagement.Common.Services;
using FlatManagement.Dto.Entities;
using Xunit;

namespace FlatManagement.Test.Bll
{
	public class AccountModelShould
	{
		[Fact]
		public void ReturnAValidAccountById()
		{
			IAccountModel iam = ServiceLocator.Instance.GetService<IAccountModel>();
			iam.GetById(new Account(1));

			Assert.NotEmpty(iam);
		}
	}
}
