﻿using FlatManagement.Bll.Interface;
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

		public ValidationResult CheckPassword(string passwordHash)
		{
			if (items.Count != 1)
			{
				return new ValidationResult("Authentication failed");
			}

			string decrypted = CryptoTool.Decrypt(passwordHash, Configuration);
			string salted = decrypted + "@" + items[0].FlatmateId;
			string hashToCheck = CryptoTool.Hash(salted);

			if (items[0].Password != hashToCheck)
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

		public void PreparePassword()
		{
			foreach (Flatmate flatmate in items)
			{
				string decrypted = CryptoTool.Decrypt(flatmate.Password, Configuration);
				string salted = decrypted + "@" + items[0].FlatmateId;
				string passwordHash = CryptoTool.Hash(salted);
				flatmate.Password = passwordHash;
			}
		}

		public void SavePassword()
		{
			IFlatmateDataAccess dal = ServiceLocator.Instance.GetService<IFlatmateDataAccess>();
			foreach (Flatmate flatmate in items)
			{
				dal.SavePassword(flatmate);
			}
		}

		protected override void Validate(Flatmate item)
		{
			IFlatmateDataAccess dal = ServiceLocator.Instance.GetService<IFlatmateDataAccess>();

			if (dal.Exists(item))
			{
				item.ValidationResult.AddError("The login already exists.");
			}
		}
	}
}
