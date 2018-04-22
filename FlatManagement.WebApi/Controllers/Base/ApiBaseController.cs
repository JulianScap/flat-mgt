﻿using FlatManagement.Bll.Tools;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace FlatManagement.WebApi.Controllers.Base
{
	[Produces("application/json")]
	[Route("api/[controller]")]
	public class ApiBaseController<TModel, TDto> : ReadOnlyApiBaseController<TModel, TDto>
		where TModel : IModel<TDto>
	{
		protected ApiBaseController(IConfiguration configuration) : base(configuration)
		{
		}
	}
}
