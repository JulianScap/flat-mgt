using FlatManagement.Bll.Interface;
using FlatManagement.Common.Bll;
using FlatManagement.Common.Dal;
using FlatManagement.Common.Services;
using FlatManagement.Dal.Interface;
using FlatManagement.Dto.Entities;
using Microsoft.Extensions.Configuration;

namespace FlatManagement.Bll.Impl
{
	internal class AccountModel : AbstractModel<Account>, IAccountModel
	{
		public AccountModel()
		{

		}

		public AccountModel(IConfiguration configuration) : base(configuration)
		{

		}

		public void GetByLogin(string login)
		{
			IAccountDataAccess dal = ServiceLocator.Instance.GetService<IAccountDataAccess>();
			items.Clear();
			items.Add(dal.GetByLogin(login));
		}

		protected override IDataAccess<Account> GetDal()
		{
			return ServiceLocator.Instance.GetService<IAccountDataAccess>();
		}
	}
}
