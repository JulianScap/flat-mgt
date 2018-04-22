using FlatManagement.Bll.Interface;
using FlatManagement.Dto.Entities;
using FlatManagement.WebApi.Controllers.Base;
using Microsoft.Extensions.Configuration;

namespace FlatManagement.WebApi.Controllers
{
	public class FlatController : ApiBaseController<IFlatModel, Flat>
	{
		public FlatController(IConfiguration configuration)
			: base(configuration)
		{
		}
	}
}
