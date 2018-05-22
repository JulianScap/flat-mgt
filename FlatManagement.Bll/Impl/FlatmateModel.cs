using System.Collections.Generic;
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
	internal class FlatmateModel : AbstractModel<Flatmate>, IFlatmateModel
	{
		public FlatmateModel()
		{

		}

		public FlatmateModel(IConfiguration configuration) : base(configuration)
		{

		}

		public void GetByFlatId(int flatId)
		{
			GetByFlat(new Flat(flatId));
		}

		public void GetByFlat(Flat flat)
		{
			IFlatmateDataAccess dal = ServiceLocator.Instance.GetService<IFlatmateDataAccess>();
			IEnumerable<Flatmate> flatmates = dal.GetByFlat(flat);
			items.Clear();
			items.AddRange(flatmates);
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

		public void GetByLogin(string login)
		{
			IFlatmateDataAccess dal = ServiceLocator.Instance.GetService<IFlatmateDataAccess>();
			items.Clear();

			Flatmate flatmate = dal.GetByLogin(login);
			if (flatmate != null)
			{
				items.Add(flatmate);
			}
		}

		protected override IDataAccess<Flatmate> GetDal()
		{
			return ServiceLocator.Instance.GetService<IFlatmateDataAccess>();
		}
	}
}
