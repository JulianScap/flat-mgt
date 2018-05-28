using System;
using System.Collections.Generic;
using System.Linq;
using FlatManagement.Bll.Impl;
using FlatManagement.Common.Dal;
using FlatManagement.Dal.Impl;
using FlatManagement.Dto.Entities;
using FlatManagement.Dto.Enums;
using FlatManagement.Test.Tools;
using FlatManagement.WebApi.Controllers;
using Xunit;

namespace FlatManagement.Test.WebApi
{
	public class PeriodTypeControllerShould : TestBase
	{
		private PeriodTypeController GetPeriodTypeService()
		{
			var conf = GetConfiguration();

			var uip = new TestUserInfoProvider();
			var dh = new DatacallsHandler(conf, uip);
			var pb = new ParametersBuilder();
			var dal = new PeriodTypeDataAccess(conf, dh, pb);
			var service = new PeriodTypeService(dal, conf);

			return new PeriodTypeController(service, conf);
		}

		[Fact]
		public void Return10ItemsOnGetAll()
		{
			PeriodTypeController ptc = GetPeriodTypeService();
			IEnumerable<PeriodType> iptm = ptc.Get();
			Assert.Equal(10, iptm.Count());
		}

		[Fact]
		public void ReturnCorrectItemOnValidGetById()
		{
			PeriodTypeController ptc = GetPeriodTypeService();
			Array periodTypeIds = Enum.GetValues(typeof(PeriodTypeEnum));

			foreach (PeriodTypeEnum periodTypeId in periodTypeIds)
			{
				IEnumerable<PeriodType> iptm = ptc.Get((int)periodTypeId);

				Assert.Single(iptm);
				Assert.Equal((int)periodTypeId, iptm.First().PeriodTypeId);
				Assert.Equal(periodTypeId.ToString(), iptm.First().Name);
			}
		}
	}
}
