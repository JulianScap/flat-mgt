using System;
using System.Collections.Generic;
using FlatManagement.Common.Services;
using FlatManagement.Dal.Impl;
using FlatManagement.Dal.Interface;
using FlatManagement.Dto.Entities;
using FlatManagement.Test.Tools;
using Xunit;

namespace FlatManagement.Test.Dal
{
	public class PeriodTypeDataAccessShould : TestBase
	{
		[Fact]
		public void ReturnAValidDataAccessObject()
		{
			ServiceLocator.Instance.SetConfiguration(GetConfiguration());
			IPeriodTypeDataAccess da = ServiceLocator.Instance.GetService<IPeriodTypeDataAccess>();

			Assert.NotNull(da);
			Assert.IsType<PeriodTypeDataAccess>(da);
		}

		[Fact]
		public void ReturnAllRows()
		{
			ServiceLocator.Instance.SetConfiguration(GetConfiguration());
			IPeriodTypeDataAccess da = ServiceLocator.Instance.GetService<IPeriodTypeDataAccess>();
			IEnumerable<PeriodType> items = da.GetAll();

			Assert.NotEmpty(items);
			Assert.All(items, item => Assert.False(String.IsNullOrEmpty(item.Name)));
			Assert.All(items, item => Assert.NotEqual(0, item.PeriodTypeId));
		}
	}
}
