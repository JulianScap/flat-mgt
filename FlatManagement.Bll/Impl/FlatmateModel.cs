using FlatManagement.Bll.Interface;
using FlatManagement.Bll.Tools;
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

		protected override IDataAccess<Flatmate> GetDal()
		{
			return ServiceLocator.Instance.GetService<IFlatmateDataAccess>();
		}
	}
}
