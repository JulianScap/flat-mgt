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
	public class FlatController : ApiBaseController<Flat>
	{
		private readonly IFlatService flatService;

		public FlatController(IFlatService flatService, IConfiguration configuration)
			: base(flatService, configuration)
		{
			this.flatService = flatService;
		}

		[HttpGet("{id}")]
		public virtual IEnumerable<Flat> Get(int id)
		{
			return GetByDto(new Flat(id));
		}
	}
}
