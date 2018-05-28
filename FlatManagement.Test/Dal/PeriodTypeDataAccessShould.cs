using System;
using System.Collections.Generic;
using FlatManagement.Common.Dal;
using FlatManagement.Dal.Impl;
using FlatManagement.Dal.Interface;
using FlatManagement.Dto.Entities;
using FlatManagement.Test.Tools;
using Xunit;

namespace FlatManagement.Test.Dal
{
	public class PeriodTypeDataAccessShould : TestBase
	{
		private IPeriodTypeDataAccess GetPeriodTypeService()
		{
			var conf = GetConfiguration();
			var uip = new TestUserInfoProvider();
			var dh = new DatacallsHandler(conf, uip);
			return new PeriodTypeDataAccess(conf, dh);
		}

		[Fact]
		public void ReturnAValidDataAccessObject()
		{
			IPeriodTypeDataAccess da = GetPeriodTypeService();

			Assert.NotNull(da);
			Assert.IsType<PeriodTypeDataAccess>(da);
		}

		[Fact]
		public void ReturnAllRows()
		{
			IPeriodTypeDataAccess da = GetPeriodTypeService();
			IEnumerable<PeriodType> items = da.GetAll();

			Assert.NotEmpty(items);
			Assert.All(items, item => Assert.False(String.IsNullOrEmpty(item.Name)));
			Assert.All(items, item => Assert.NotEqual(0, item.PeriodTypeId));
		}

		[Theory]
		[InlineData(1)]
		[InlineData(2)]
		[InlineData(3)]
		[InlineData(4)]
		[InlineData(5)]
		public void ReturnById(int periodTypeId)
		{
			IPeriodTypeDataAccess da = GetPeriodTypeService();
			PeriodType periodType = da.GetById(new PeriodType() { PeriodTypeId = periodTypeId });
			Assert.NotNull(periodType);
			Assert.Equal(periodTypeId, periodType.PeriodTypeId);
		}
	}
}
