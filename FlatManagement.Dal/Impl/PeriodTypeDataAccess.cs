using FlatManagement.Common.Dal;
using FlatManagement.Dal.Interface;
using FlatManagement.Dto.Entities;
using Microsoft.Extensions.Configuration;

namespace FlatManagement.Dal.Impl
{
	public class PeriodTypeDataAccess : ReadOnlyAbstractDataAccess<PeriodType>, IPeriodTypeDataAccess
	{
		public PeriodTypeDataAccess(IConfiguration configuration, IDatacallsHandler handler, IParametersBuilder parametersBuilder) : base(configuration, handler, parametersBuilder)
		{

		}
	}
}
