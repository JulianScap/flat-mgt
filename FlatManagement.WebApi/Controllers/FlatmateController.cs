using FlatManagement.Bll.Interface;
using FlatManagement.Dto.Entities;
using FlatManagement.WebApi.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace FlatManagement.WebApi.Controllers
{
	public class FlatmateController : ApiBaseController<IFlatmateModel, Flatmate>
	{
		public FlatmateController(IConfiguration configuration)
			: base(configuration)
		{
		}

		[HttpGet("{id}")]
		public virtual IFlatmateModel Get(int id)
		{
			return GetByDto(new Flatmate(id));
		}
	}
}
