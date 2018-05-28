using System.Collections.Generic;
using FlatManagement.Common.Bll;
using FlatManagement.Common.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace FlatManagement.WebApi.Controllers.Base
{
	public abstract class ReadOnlyApiBaseController<TDto> : AbstractController
		where TDto : IDto, new()
	{
		private readonly IReadOnlyService<TDto> service;

		protected ReadOnlyApiBaseController(IReadOnlyService<TDto> service, IConfiguration configuration)
			: base(configuration)
		{
			this.service = service;
		}

		protected IEnumerable<TDto> DeserialiseBody()
		{
			string content = base.GetBodyAsString();
			return JsonConvert.DeserializeObject<IEnumerable<TDto>>(content);
		}

		[HttpGet]
		public virtual IEnumerable<TDto> Get()
		{
			return service.GetForUser();
		}

		protected IEnumerable<TDto> GetByDto(TDto item)
		{
			return new TDto[1] { service.GetById(item) };
		}
	}
}
