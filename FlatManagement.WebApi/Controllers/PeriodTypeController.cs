using FlatManagement.Bll.Interface;
using FlatManagement.Common.Services;
using FlatManagement.Dto.Entities;
using FlatManagement.Dto.Enums;
using FlatManagement.WebApi.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace FlatManagement.WebApi.Controllers
{
	public class PeriodTypeController : ReadOnlyApiBaseController<IPeriodTypeModel, PeriodType>
	{
		public PeriodTypeController(IConfiguration configuration)
			: base(configuration)
		{
		}

		[HttpGet("{periodTypeId}")]
		public virtual IPeriodTypeModel Get(int periodTypeId)
		{
			IPeriodTypeModel ipt = ServiceLocator.Instance.GetService<IPeriodTypeModel>();
			ipt.GetById(new PeriodType((PeriodTypeEnum)periodTypeId));
			return ipt;
		}
	}
}
