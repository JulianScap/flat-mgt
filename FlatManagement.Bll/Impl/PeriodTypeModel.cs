using FlatManagement.Bll.Interface;
using FlatManagement.Bll.Tools;
using FlatManagement.Common.Services;
using FlatManagement.Dal.Interface;
using FlatManagement.Dto.Entities;
using Microsoft.Extensions.Configuration;

namespace FlatManagement.Bll.Impl
{
	internal class PeriodTypeModel : AbstractModel<PeriodType>, IPeriodTypeModel
	{
		public PeriodTypeModel()
		{

		}

		public PeriodTypeModel(IConfiguration configuration) : base(configuration)
		{

		}

		protected override IDataAccess<PeriodType> GetDal()
		{
			return ServiceLocator.Instance.GetService<IPeriodTypeDataAccess>();
		}
	}
}
