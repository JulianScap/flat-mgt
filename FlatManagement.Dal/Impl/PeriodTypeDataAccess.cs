using FlatManagement.Dal.Interface;
using FlatManagement.Dal.Tools;
using FlatManagement.Dto.Entities;
using Microsoft.Extensions.Configuration;

namespace FlatManagement.Dal.Impl
{
	internal class PeriodTypeDataAccess : ReadOnlyAbstractDataAccess<PeriodType>, IPeriodTypeDataAccess
	{
		public PeriodTypeDataAccess(IConfiguration configuration) : base(configuration)
		{

		}
	}
}
