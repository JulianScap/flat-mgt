using System.Collections.Generic;
using FlatManagement.Bll.Interface;
using FlatManagement.Dto.Entities;
using FlatManagement.WebApi.Controllers.Base;
using FlatManagement.WebApi.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace FlatManagement.WebApi.Controllers
{
	[TokenAuthorize]
	public class TaskController : ApiBaseController<Task>
	{
		public TaskController(ITaskService service, IConfiguration configuration)
			: base(service, configuration)
		{
		}

		[HttpGet("{id}")]
		public virtual IEnumerable<Task> Get(int id)
		{
			return GetByDto(new Task(id));
		}
	}
}
