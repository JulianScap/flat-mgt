using FlatManagement.Bll.Interface;
using FlatManagement.Common.Bll;
using FlatManagement.Common.Dal;
using FlatManagement.Dal.Interface;
using FlatManagement.Dto.Entities;
using Microsoft.Extensions.Configuration;

namespace FlatManagement.Bll.Impl
{
	public class PeriodTypeService : AbstractReadOnlyService<PeriodType>, IPeriodTypeService
	{
		protected override IReadOnlyDataAccess<PeriodType> ReadOnlyDal { get => periodTypeDataAccess; }

		private readonly IPeriodTypeDataAccess periodTypeDataAccess;

		public PeriodTypeService(IPeriodTypeDataAccess periodTypeDataAccess, IConfiguration configuration) : base(configuration)
		{
			this.periodTypeDataAccess = periodTypeDataAccess;
		}
	}
}
