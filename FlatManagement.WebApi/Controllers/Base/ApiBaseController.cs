using FlatManagement.Bll.Tools;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace FlatManagement.WebApi.Controllers.Base
{
	[Produces("application/json")]
	[Route("api/[controller]")]
	public class ApiBaseController<TModel> : ReadOnlyApiBaseController<TModel>
		where TModel : IModel
	{
		protected ApiBaseController(IConfiguration configuration) : base(configuration)
		{
		}
	}
}
