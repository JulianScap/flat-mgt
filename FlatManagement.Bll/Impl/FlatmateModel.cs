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

		protected override IDataAccess<Flatmate> GetDal()
		{
			return ServiceLocator.Instance.GetService<IFlatmateDataAccess>();
		}
	}
}
