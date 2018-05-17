using FlatManagement.Bll.Interface;
using FlatManagement.Common.Bll;
using FlatManagement.Common.Dal;
using FlatManagement.Common.Security;
using FlatManagement.Common.Services;
using FlatManagement.Common.Validation;
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

			Account account = dal.GetByLogin(login);
			if (account != null)
			{
				items.Add(account);
			}
		}

		protected override IDataAccess<Account> GetDal()
		{
			return ServiceLocator.Instance.GetService<IAccountDataAccess>();
		}

		public ValidationResult CheckPassword(string passwordHash)
		{
			string decrypted = CryptoTool.Decrypt(passwordHash, Configuration);

			if (items.Count != 1 || items[0].Password != decrypted)
			{
				return new ValidationResult("Authentication failed");
			}

			return new ValidationResult();
		}
	}
}
