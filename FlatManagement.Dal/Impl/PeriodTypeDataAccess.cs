using FlatManagement.Common.Dto;
using FlatManagement.Common.Exceptions;
using FlatManagement.Dal.Interface;
using FlatManagement.Dal.Tools;
using FlatManagement.Dto.Entities;
using Microsoft.Extensions.Configuration;

namespace FlatManagement.Dal.Impl
{
	internal class PeriodTypeDataAccess : AbstractDataAccess<PeriodType>, IPeriodTypeDataAccess
	{
		public PeriodTypeDataAccess(IConfiguration configuration) : base(configuration)
		{

		}

		public override void Delete(IDto item)
		{
			throw new DisabledOperationException();
		}

		public override void Insert(PeriodType item)
		{
			throw new DisabledOperationException();
		}

		public override void Update(PeriodType item)
		{
			throw new DisabledOperationException();
		}
	}
}
