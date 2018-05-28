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
	public class FlatmateController : ApiBaseController<Flatmate>
	{
		public FlatmateController(IFlatmateService service, IConfiguration configuration)
			: base(service, configuration)
		{
		}

		[HttpGet("{id}")]
		public virtual IEnumerable<Flatmate> Get(int id)
		{
			return GetByDto(new Flatmate(id));
		}
	}
}
