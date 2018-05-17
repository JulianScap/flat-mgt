using FlatManagement.Bll.Interface;
using FlatManagement.Dto.Entities;
using FlatManagement.WebApi.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace FlatManagement.WebApi.Controllers
{
	public class TaskController : ApiBaseController<ITaskModel, Task>
	{
		public TaskController(IConfiguration configuration)
			: base(configuration)
		{
		}

		[HttpGet("{id}")]
		public virtual ITaskModel Get(int id)
		{
			return GetByDto(new Task(id));
		}
	}
}
