using FlatManagement.Bll.Interface;
using FlatManagement.Common.Bll;
using FlatManagement.Common.Dal;
using FlatManagement.Dal.Interface;
using FlatManagement.Dto.Entities;
using Microsoft.Extensions.Configuration;

namespace FlatManagement.Bll.Impl
{
	public class TaskService : AbstractService<Task>, ITaskService
	{
		protected override IDataAccess<Task> Dal { get => taskDataAccess; }

		private readonly ITaskDataAccess taskDataAccess;

		public TaskService(ITaskDataAccess taskDataAccess, IConfiguration configuration) : base(configuration)
		{
			this.taskDataAccess = taskDataAccess;
		}
	}
}
