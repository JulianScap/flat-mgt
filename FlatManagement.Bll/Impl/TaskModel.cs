using FlatManagement.Bll.Interface;
using FlatManagement.Bll.Tools;
using FlatManagement.Common.Services;
using FlatManagement.Dal.Interface;
using FlatManagement.Dal.Tools;
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
