using FlatManagement.Bll.Interface;
using FlatManagement.Bll.Tools;
using FlatManagement.Common.Services;
using FlatManagement.Dal.Interface;
using FlatManagement.Dal.Tools;
using FlatManagement.Dto.Entities;
using Microsoft.Extensions.Configuration;

namespace FlatManagement.Bll.Impl
{
	internal class PeriodTypeModel : AbstractReadOnlyModel<PeriodType>, IPeriodTypeModel
	{
		public PeriodTypeModel()
		{

		}

		public PeriodTypeModel(IConfiguration configuration) : base(configuration)
		{

		}

		protected override IReadOnlyDataAccess<PeriodType> GetReadOnlyDal()
		{
			return ServiceLocator.Instance.GetService<IPeriodTypeDataAccess>();
		}
	}
}
