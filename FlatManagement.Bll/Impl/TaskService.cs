using FlatManagement.Bll.Interface;
using FlatManagement.Common.Bll;
using FlatManagement.Dal.Interface;
using FlatManagement.Dto.Entities;
using Microsoft.Extensions.Configuration;

namespace FlatManagement.Bll.Impl
{
	public class TaskService : AbstractService<Task>, ITaskService
	{
		private readonly ITaskDataAccess taskDataAccess;

		public TaskService(ITaskDataAccess taskDataAccess, IConfiguration configuration) : base(taskDataAccess, configuration)
		{
			this.taskDataAccess = taskDataAccess;
		}
	}
}
