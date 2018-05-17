using FlatManagement.Bll.Interface;
using FlatManagement.Common.Bll;
using FlatManagement.Common.Services;
using FlatManagement.Dal.Interface;
using FlatManagement.Common.Dal;
using FlatManagement.Dto.Entities;
using Microsoft.Extensions.Configuration;

namespace FlatManagement.Bll.Impl
{
	internal class TaskModel : AbstractModel<Task>, ITaskModel
	{
		public TaskModel()
		{

		}

		public TaskModel(IConfiguration configuration) : base(configuration)
		{

		}

		protected override IDataAccess<Task> GetDal()
		{
			return ServiceLocator.Instance.GetService<ITaskDataAccess>();
		}
	}
}
