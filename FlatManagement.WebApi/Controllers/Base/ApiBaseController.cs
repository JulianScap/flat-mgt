using System.Collections.Generic;
using FlatManagement.Common.Bll;
using FlatManagement.Common.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace FlatManagement.WebApi.Controllers.Base
{
	public abstract class ApiBaseController<TDto> : ReadOnlyApiBaseController<TDto>
		where TDto : IDto, new()
	{
		private readonly IService<TDto> service;

		protected ApiBaseController(IService<TDto> service, IConfiguration configuration) : base(service, configuration)
		{
			this.service = service;
		}

		[HttpPut]
		[HttpPost]
		public virtual IEnumerable<TDto> PersistAll()
		{
			IEnumerable<TDto> items = DeserialiseBody();
			service.Save(items);
			return items;
		}

		[HttpDelete]
		public virtual IEnumerable<TDto> DeleteAll()
		{
			IEnumerable<TDto> items = DeserialiseBody();
			service.Delete(items);
			return items;
		}
	}
}
