using FlatManagement.Bll.Interface;
using FlatManagement.WebApi.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace FlatManagement.WebApi.Controllers
{
	public class FlatController : ApiBaseController<IFlatModel>
	{
		public FlatController(IConfiguration configuration)
			: base(configuration)
		{
		}

		[HttpGet("{id}")]
		public IFlatModel Get(int id)
		{
			return base.Get(id);
		}
	}
}
