using FlatManagement.Bll.Interface;
using FlatManagement.Common.Bll;
using FlatManagement.Common.Security;
using FlatManagement.Common.Validation;
using FlatManagement.Dal.Interface;
using FlatManagement.Dto.Entities;
using Microsoft.Extensions.Configuration;

namespace FlatManagement.Bll.Impl
{
	public class FlatmateService : AbstractService<Flatmate>, IFlatmateService
	{
		private readonly IFlatmateDataAccess flatmateDataAccess;
		private readonly ICryptoHelper cryptoHelper;

		public FlatmateService(IFlatmateDataAccess flatmateDataAccess, IConfiguration configuration, ICryptoHelper cryptoHelper) : base(flatmateDataAccess, configuration)
		{
			this.flatmateDataAccess = flatmateDataAccess;
			this.cryptoHelper = cryptoHelper;
		}

		public ValidationResult CheckPassword(Flatmate flatmate, string passwordHash)
		{
			if (flatmate == null)
			{
				return new ValidationResult("Authentication failed");
			}

			string decrypted = cryptoHelper.Decrypt(passwordHash);
			string salted = decrypted + "@" + flatmate.FlatmateId;
			string hashToCheck = cryptoHelper.Hash(salted);

			if (flatmate.Password != hashToCheck)
			{
				return new ValidationResult("Authentication failed");
			}

			return new ValidationResult();
		}

		public Flatmate GetByLogin(string login)
		{
			return flatmateDataAccess.GetByLogin(login);
		}

		public void PreparePassword(Flatmate flatmate)
		{
			string decrypted = cryptoHelper.Decrypt(flatmate.Password);
			string salted = decrypted + "@" + flatmate.FlatmateId;
			string passwordHash = cryptoHelper.Hash(salted);
			flatmate.Password = passwordHash;
		}

		public void SavePassword(Flatmate flatmate)
		{
			flatmateDataAccess.SavePassword(flatmate);
		}
	}
}
