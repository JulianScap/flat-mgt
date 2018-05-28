using System;
using System.Collections.Generic;
using FlatManagement.Bll.Impl;
using FlatManagement.Bll.Interface;
using FlatManagement.Common.Dal;
using FlatManagement.Dal.Impl;
using FlatManagement.Dto.Entities;
using FlatManagement.Test.Tools;
using Xunit;

namespace FlatManagement.Test.Bll
{
	public class PeriodTypeModelShould : TestBase
	{
		private IPeriodTypeService GetPeriodTypeService()
		{
			var conf = GetConfiguration();
			var uip = new TestUserInfoProvider();
			var dh = new DatacallsHandler(conf, uip);
			var dal = new PeriodTypeDataAccess(conf, dh);
			return new PeriodTypeService(dal, conf);
		}

		[Fact]
		public void BeAbleToGetAllDbItems()
		{
			IPeriodTypeService periodTypeService = GetPeriodTypeService();
			IEnumerable<PeriodType> periodTypes = periodTypeService.GetAll();

			Assert.NotEmpty(periodTypes);
			Assert.All(periodTypes, item => Assert.False(String.IsNullOrEmpty(item.Name)));
			Assert.All(periodTypes, item => Assert.NotEqual(0, item.PeriodTypeId));
		}
	}
}
