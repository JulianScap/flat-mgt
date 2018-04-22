using FlatManagement.Bll.Interface;
using FlatManagement.Dto.Entities;
using FlatManagement.WebApi.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace FlatManagement.WebApi.Controllers
{
	public class PeriodTypeController : ReadOnlyApiBaseController<IPeriodTypeModel, PeriodType>
	{
		public PeriodTypeController(IConfiguration configuration)
			: base(configuration)
		{
		}

		[HttpGet]
		public virtual IPeriodTypeModel Get(int periodTypeId)
		{
			return Get(new PeriodType() { PeriodTypeId = periodTypeId });
		}
	}
}
