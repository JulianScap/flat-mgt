using FlatManagement.Dal.Tools;
using FlatManagement.Dal.Interface;
using FlatManagement.Dto.Entities;
using Microsoft.Extensions.Configuration;

namespace FlatManagement.Dal.Impl
{
	internal class TaskDataAccess : AbstractDataAccess<Task>, ITaskDataAccess
	{
		protected TaskDataAccess(IConfiguration configuration) : base(configuration)
		{
		}
	}
}
