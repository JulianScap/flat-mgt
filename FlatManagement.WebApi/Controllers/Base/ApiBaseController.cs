using FlatManagement.Bll.Tools;
using FlatManagement.Common.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace FlatManagement.WebApi.Controllers.Base
{
	[Produces("application/json")]
	[Route("api/[controller]")]
	public class ApiBaseController<TModel, TDto> : ReadOnlyApiBaseController<TModel, TDto>
		where TModel : IModel<TDto>
		where TDto : IDto, new()
	{
		protected ApiBaseController(IConfiguration configuration) : base(configuration)
		{
		}
	}
}
