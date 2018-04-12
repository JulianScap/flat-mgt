using FlatManagement.Bll;
using FlatManagement.Bll.Interface;
using FlatManagement.WebApi.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace FlatManagement.WebApi.Controllers
{
	public class PeriodTypeController : ApiBaseController
	{
		public PeriodTypeController(IConfiguration configuration)
			: base(configuration)
		{
		}

		[HttpGet]
		public IPeriodTypeModel Get()
		{
			IPeriodTypeModel ipt = BllFactory.Instance.Get<IPeriodTypeModel>();

			ipt.GetAll();

			return ipt;
		}

		[HttpGet("{id}")]
		public IPeriodTypeModel Get(int id)
		{
			IPeriodTypeModel ipt = BllFactory.Instance.Get<IPeriodTypeModel>();

			ipt.GetAll();
			ipt.RemoveAll(x => x.PeriodTypeId != id);

			return ipt;
		}
	}
}
