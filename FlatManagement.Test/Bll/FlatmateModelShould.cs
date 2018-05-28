﻿using System.Collections.Generic;
using FlatManagement.Bll.Impl;
using FlatManagement.Bll.Interface;
using FlatManagement.Common.Dal;
using FlatManagement.Dal.Impl;
using FlatManagement.Dto.Entities;
using FlatManagement.Test.Tools;
using Xunit;

namespace FlatManagement.Test.Bll
{
	public class FlatmateModelShould : TestBase
	{
		private IFlatmateService GetFlatmateService()
		{
			var conf = GetConfiguration();
			var uip = new TestUserInfoProvider();
			var dh = new DatacallsHandler(conf, uip);
			var dal = new FlatmateDataAccess(conf, dh);
			return new FlatmateService(dal, conf);
		}

		[Fact]
		public void ReturnAValidAccountByLogin()
		{
			IFlatmateService fs = GetFlatmateService();
			IEnumerable<Flatmate> flatmates = fs.GetForUser();
			Assert.NotEmpty(flatmates);
		}
	}
}
