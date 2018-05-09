using FlatManagement.Bll.Interface;
using FlatManagement.Common.Services;
using FlatManagement.Dto.Entities;
using FlatManagement.WebApi.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace FlatManagement.WebApi.Controllers
{
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

		[HttpGet("{nickname}/{flatName}")]
		public virtual IFlatmateModel Get(string nickname, string flatName)
		{
			IFlatmateModel itm = ServiceLocator.Instance.GetService<IFlatmateModel>();
			itm.GetByNameAndFlatName(nickname, flatName);
			return itm;
		}
	}
}
