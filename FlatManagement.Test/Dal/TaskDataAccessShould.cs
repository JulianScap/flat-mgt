﻿using FlatManagement.Common.Dal;
using FlatManagement.Dal.Impl;
using FlatManagement.Dal.Interface;
using FlatManagement.Test.Tools;
using Xunit;

namespace FlatManagement.Test.Dal
{
	public class TaskDataAccessShould : TestBase
	{
		private ITaskDataAccess GetPeriodTypeService()
		{
			var conf = GetConfiguration();
			var uip = new TestUserInfoProvider();
			var dh = new DatacallsHandler(conf, uip);
			var pb = new ParametersBuilder();
			return new TaskDataAccess(conf, dh, pb);
		}

		[Fact]
		public void ReturnAValidDataAccessObject()
		{
			ITaskDataAccess da = GetPeriodTypeService();

			Assert.NotNull(da);
			Assert.IsType<TaskDataAccess>(da);
		}
	}
}
