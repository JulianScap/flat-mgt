using FlatManagement.Bll.Interface;
using FlatManagement.Common.Bll;
using FlatManagement.Dal.Interface;
using FlatManagement.Dto.Entities;
using Microsoft.Extensions.Configuration;

namespace FlatManagement.Bll.Impl
{
	public class PeriodTypeService : AbstractReadOnlyService<PeriodType>, IPeriodTypeService
	{
		private readonly IPeriodTypeDataAccess periodTypeDataAccess;

		public PeriodTypeService(IPeriodTypeDataAccess periodTypeDataAccess, IConfiguration configuration) : base(periodTypeDataAccess, configuration)
		{
			this.periodTypeDataAccess = periodTypeDataAccess;
		}
	}
}
