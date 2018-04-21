using FlatManagement.Bll.Interface;
using FlatManagement.Bll.Tools;
using FlatManagement.Common.Services;
using FlatManagement.Dal.Interface;
using FlatManagement.Dal.Tools;
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
	}
}
