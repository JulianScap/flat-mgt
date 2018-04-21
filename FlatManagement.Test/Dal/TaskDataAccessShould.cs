using FlatManagement.Common.Services;
using FlatManagement.Dal.Impl;
using FlatManagement.Dal.Interface;
using FlatManagement.Test.Tools;
using Xunit;

namespace FlatManagement.Test.Dal
{
	public class TaskDataAccessShould : TestBase
	{
		[Fact]
		public void ReturnAValidDataAccessObject()
		{
			ITaskDataAccess da = ServiceLocator.Instance.GetService<ITaskDataAccess>();

			Assert.NotNull(da);
			Assert.IsType<TaskDataAccess>(da);
		}
	}
}
