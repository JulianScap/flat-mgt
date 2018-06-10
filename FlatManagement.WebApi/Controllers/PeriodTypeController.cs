using System.Collections.Generic;
using FlatManagement.Bll.Interface;
using FlatManagement.Dto.Entities;
using FlatManagement.WebApi.Controllers.Base;
using FlatManagement.WebApi.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace FlatManagement.WebApi.Controllers
{
	[TokenAuthorize]
	public class PeriodTypeController : ReadOnlyApiBaseController<PeriodType>
	{
		private readonly IPeriodTypeService service;

		public PeriodTypeController(IPeriodTypeService service, IConfiguration configuration)
			: base(service, configuration)
		{
			this.service = service;
		}

		[HttpGet("{id}")]
		public virtual IEnumerable<PeriodType> Get(int id)
		{
			return GetByDto(new PeriodType(id));
		}

		public override IEnumerable<PeriodType> Get()
		{
			return service.GetAll();
		}
	}
}
