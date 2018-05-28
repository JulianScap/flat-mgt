using FlatManagement.Bll.Interface;
using FlatManagement.Common.Bll;
using FlatManagement.Common.Dal;
using FlatManagement.Common.Security;
using FlatManagement.Common.Validation;
using FlatManagement.Dal.Interface;
using FlatManagement.Dto.Entities;
using Microsoft.Extensions.Configuration;

namespace FlatManagement.Bll.Impl
{
	public class FlatmateService : AbstractService<Flatmate>, IFlatmateService
	{
		protected override IDataAccess<Flatmate> Dal { get => flatmateDataAccess; }
		private IFlatmateDataAccess flatmateDataAccess;

		public FlatmateService(IFlatmateDataAccess flatmateDataAccess, IConfiguration configuration)
			: base(configuration)
		{
			this.flatmateDataAccess = flatmateDataAccess;
		}

		public ValidationResult CheckPassword(Flatmate flatmate, string passwordHash)
		{
			if (flatmate == null)
			{
				return new ValidationResult("Authentication failed");
			}

			string decrypted = CryptoTool.Decrypt(passwordHash, Configuration);
			string salted = decrypted + "@" + flatmate.FlatmateId;
			string hashToCheck = CryptoTool.Hash(salted);

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
			string decrypted = CryptoTool.Decrypt(flatmate.Password, Configuration);
			string salted = decrypted + "@" + flatmate.FlatmateId;
			string passwordHash = CryptoTool.Hash(salted);
			flatmate.Password = passwordHash;
		}

		public void SavePassword(Flatmate flatmate)
		{
			flatmateDataAccess.SavePassword(flatmate);
		}
	}
}
