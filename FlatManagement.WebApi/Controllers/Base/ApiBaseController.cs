using FlatManagement.Common.Bll;
using FlatManagement.Common.Dto;
using FlatManagement.Common.Validation;
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
		public virtual object PersistAll()
		{
			TModel model = DeserialiseBody();
			ValidationResult result = model.PersistAll();
			if (result.IsValid)
			{
				return model;
			}
			else
			{
				return result;
			}
		}

		[HttpDelete]
		public virtual TModel DeleteAll()
		{
			TModel model = DeserialiseBody();
			model.DeleteAll();
			return model;
		}
	}
}
