using FlatManagement.Common.Bll;
using FlatManagement.Common.Dto;
using FlatManagement.Common.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace FlatManagement.WebApi.Controllers.Base
{
	public abstract class ReadOnlyApiBaseController<TModel, TDto> : AbstractController
		where TModel : IReadOnlyModel<TDto>
		where TDto : IDto, new()
	{
		protected ReadOnlyApiBaseController(IConfiguration configuration)
			: base(configuration)
		{
		}

		protected TModel DeserialiseBody()
		{
			string content = base.GetBodyAsString();
			TModel result = ModelSerialiser.Instance.Deserialize<TModel>(content);
			return result;
		}

		[HttpGet]
		public virtual TModel Get()
		{
			TModel ipt = ServiceLocator.Instance.GetService<TModel>();
			ipt.GetAll();
			return ipt;
		}

		protected TModel GetByDto(TDto item)
		{
			TModel itm = ServiceLocator.Instance.GetService<TModel>();
			itm.GetById(item);
			return itm;
		}
	}
}
