using FlatManagement.Bll.Interface;
using FlatManagement.Common.Services;
using FlatManagement.Dto.Entities;
using FlatManagement.WebApi.Controllers.Base;
using FlatManagement.WebApi.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace FlatManagement.WebApi.Controllers
{
	[TokenAuthorize]
	public class FlatmateController : ApiBaseController<IFlatmateModel, Flatmate>
	{
		public FlatmateController(IConfiguration configuration)
			: base(configuration)
		{
		}

		[HttpGet("{id}")]
		public virtual IFlatmateModel Get(int id)
		{
			return GetByDto(new Flatmate(id));
		}

		[HttpGet("byFlat/{flatId}")]
		public virtual IFlatmateModel GetByFlat(int flatId)
		{
			IFlatmateModel model = ServiceLocator.Instance.GetService<IFlatmateModel>();

			model.GetByFlatId(flatId);

			return model;
		}
	}
}
