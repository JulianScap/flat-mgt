using FlatManagement.Bll.Interface;
using FlatManagement.Common.Services;
using FlatManagement.Dto.Entities;
using FlatManagement.WebApi.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace FlatManagement.WebApi.Controllers
{
	public class FlatController : ApiBaseController<IFlatModel, Flat>
	{
		public FlatController(IConfiguration configuration)
			: base(configuration)
		{
		}

		[HttpGet("{flatId}")]
		public virtual IFlatModel Get(int flatId)
		{
			IFlatModel ipt = ServiceLocator.Instance.GetService<IFlatModel>();
			ipt.GetById(new Flat() { FlatId = flatId });
			return ipt;
		}
	}
}
