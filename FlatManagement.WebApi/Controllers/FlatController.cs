using FlatManagement.Bll.Interface;
using FlatManagement.Dto.Entities;
using FlatManagement.WebApi.Controllers.Base;
using FlatManagement.WebApi.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace FlatManagement.WebApi.Controllers
{
	[TokenAuthorize]
	public class FlatController : ApiBaseController<IFlatModel, Flat>
	{
		public FlatController(IConfiguration configuration)
			: base(configuration)
		{
		}

		[HttpGet("{id}")]
		public virtual IFlatModel Get(int id)
		{
			return GetByDto(new Flat(id));
		}

		[HttpGet("byLogin")]
		public virtual string GetByLogin()
		{
			return "hello";
		}
	}
}
