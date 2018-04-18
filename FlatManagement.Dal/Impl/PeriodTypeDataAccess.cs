using FlatManagement.Dal.Interface;
using FlatManagement.Dto.Entities;
using Microsoft.Extensions.Configuration;

namespace FlatManagement.Dal.Impl
{
	internal class PeriodTypeDataAccess : AbstractDataAccess<PeriodType>, IPeriodTypeDataAccess
	{
		public PeriodTypeDataAccess(IConfiguration configuration) : base(configuration)
		{

		}
	}
}
