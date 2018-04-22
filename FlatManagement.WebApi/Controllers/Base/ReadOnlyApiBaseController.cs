using FlatManagement.Bll.Tools;
using FlatManagement.Common.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace FlatManagement.WebApi.Controllers.Base
{
	[Produces("application/json")]
	[Route("api/[controller]")]
	public class ReadOnlyApiBaseController<TModel> : Controller
		where TModel : IReadOnlyModel
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

		[HttpGet]
		protected virtual TModel Get(params object[] ids)
		{
			TModel ipt = ServiceLocator.Instance.GetService<TModel>();
			ipt.GetById(ids);
			return ipt;
		}
	}
}
