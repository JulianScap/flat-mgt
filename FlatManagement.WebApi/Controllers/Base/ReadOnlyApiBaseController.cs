using System.IO;
using FlatManagement.Common.Bll;
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

		protected TModel DeserialiseBody()
		{
			using (StreamReader reader = new StreamReader(this.Request.Body))
			{
				string content = reader.ReadToEnd();
				TModel result = ModelSerialiser.Instance.Deserialize<TModel>(content);
				result.Configuration = configuration;
				return result;
			}
		}

		[HttpGet]
		public virtual TModel Get()
		{
			TModel ipt = ServiceLocator.Instance.GetService<TModel>();
			ipt.GetAll();
			return ipt;
		}
	}
}
