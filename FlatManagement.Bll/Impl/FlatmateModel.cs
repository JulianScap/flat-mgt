using FlatManagement.Bll.Interface;
using FlatManagement.Common.Bll;
using FlatManagement.Common.Services;
using FlatManagement.Dal.Interface;
using FlatManagement.Common.Dal;
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

		protected override IDataAccess<Flatmate> GetDal()
		{
			return ServiceLocator.Instance.GetService<IFlatmateDataAccess>();
		}
	}
}
