using FlatManagement.Common.Bll;
using FlatManagement.Common.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace FlatManagement.WebApi.Controllers.Base
{
	public abstract class ApiBaseController<TModel, TDto> : ReadOnlyApiBaseController<TModel, TDto>
		where TModel : IModel<TDto>
		where TDto : IDto, new()
	{
		protected ApiBaseController(IConfiguration configuration) : base(configuration)
		{
		}

		[HttpPut]
		[HttpPost]
		public TModel PersistAll()
		{
			TModel model = DeserialiseBody();
			model.PersistAll();
			return model;
		}

		[HttpDelete]
		public TModel DeleteAll()
		{
			TModel model = DeserialiseBody();
			model.DeleteAll();
			return model;
		}
	}
}
