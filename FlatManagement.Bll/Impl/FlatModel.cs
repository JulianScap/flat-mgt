using System.Collections.Generic;
using FlatManagement.Bll.Interface;
using FlatManagement.Common.Bll;
using FlatManagement.Common.Dal;
using FlatManagement.Common.Services;
using FlatManagement.Dal.Interface;
using FlatManagement.Dto.Entities;
using Microsoft.Extensions.Configuration;

namespace FlatManagement.Bll.Impl
{
	internal class FlatModel : AbstractModel<Flat>, IFlatModel
	{
		public FlatModel()
		{

		}

		public FlatModel(IConfiguration configuration) : base(configuration)
		{

		}

		protected override IDataAccess<Flat> GetDal()
		{
			return ServiceLocator.Instance.GetService<IFlatDataAccess>();
		}

		public void GetByLogin(string login)
		{
			IFlatDataAccess dal = ServiceLocator.Instance.GetService<IFlatDataAccess>();

			IEnumerable<Flat> flats = dal.GetByLogin(login);

			items.Clear();
			items.AddRange(flats);
		}
	}
}
