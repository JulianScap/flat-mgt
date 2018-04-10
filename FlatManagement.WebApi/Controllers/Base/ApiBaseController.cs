using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace FlatManagement.WebApi.Controllers.Base
{
	[Produces("application/json")]
	[Route("api/[controller]")]
	public class ApiBaseController : Controller
	{
		protected IConfiguration configuration;

		protected ApiBaseController(IConfiguration configuration)
		{
			this.configuration = configuration;
		}
	}
}
