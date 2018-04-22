using FlatManagement.Bll.Interface;
using FlatManagement.WebApi.Controllers.Base;
using Microsoft.Extensions.Configuration;

namespace FlatManagement.WebApi.Controllers
{
	public class PeriodTypeController : ReadOnlyApiBaseController<IPeriodTypeModel>
	{
		public PeriodTypeController(IConfiguration configuration)
			: base(configuration)
		{
		}
	}
}
