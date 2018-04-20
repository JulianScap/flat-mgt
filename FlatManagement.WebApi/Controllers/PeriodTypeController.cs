using FlatManagement.Bll.Interface;
using FlatManagement.Common.Services;
using FlatManagement.WebApi.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace FlatManagement.WebApi.Controllers
{
	public class PeriodTypeController : ApiBaseController<IPeriodTypeModel>
	{
		public PeriodTypeController(IConfiguration configuration)
			: base(configuration)
		{
		}

		[HttpGet("{id}")]
		public IPeriodTypeModel Get(int id)
		{
			IPeriodTypeModel ipt = ServiceLocator.Instance.GetService<IPeriodTypeModel>();

			ipt.GetAll();
			ipt.RemoveAll(x => x.PeriodTypeId != id);

			return ipt;
		}
	}
}
