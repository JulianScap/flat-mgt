using FlatManagement.Bll.Interface;
using FlatManagement.Common.Bll;
using FlatManagement.Common.Services;
using FlatManagement.Dal.Interface;
using FlatManagement.Common.Dal;
using FlatManagement.Dto.Entities;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

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

		public void GetByNameAndFlatName(string nickname, string flatName)
		{
			IFlatmateDataAccess dal = ServiceLocator.Instance.GetService<IFlatmateDataAccess>();
			IEnumerable<Flatmate> flatmates = dal.GetByNameAndFlatName(nickname, flatName);
			items.Clear();
			items.AddRange(flatmates);
		}

		protected override IDataAccess<Flatmate> GetDal()
		{
			return ServiceLocator.Instance.GetService<IFlatmateDataAccess>();
		}
	}
}
