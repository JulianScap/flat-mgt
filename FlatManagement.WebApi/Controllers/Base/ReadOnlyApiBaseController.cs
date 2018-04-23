﻿using FlatManagement.Bll.Tools;
using FlatManagement.Common.Dto;
using FlatManagement.Common.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace FlatManagement.WebApi.Controllers.Base
{
	[Produces("application/json")]
	[Route("api/[controller]")]
	public class ReadOnlyApiBaseController<TModel, TDto> : Controller
		where TModel : IReadOnlyModel<TDto>
		where TDto : IDto, new()
	{
		protected IConfiguration configuration;

		protected ReadOnlyApiBaseController(IConfiguration configuration)
		{
			this.configuration = configuration;
		}

		[HttpGet]
		public virtual TModel Get()
		{
			TModel ipt = ServiceLocator.Instance.GetService<TModel>();
			ipt.GetAll();
			return ipt;
		}

		protected virtual TModel Get(TDto ids)
		{
			TModel ipt = ServiceLocator.Instance.GetService<TModel>();
			ipt.GetById(ids);
			return ipt;
		}
	}
}
