using System;
using System.Collections.Generic;
using FlatManagement.Dal;
using FlatManagement.Dal.Impl;
using FlatManagement.Dal.Interface;
using FlatManagement.Dto.Entities;
using Xunit;

namespace FlatManagement.Test.Dal
{
	public class PeriodTypeDataAccessShould
	{
		[Fact]
		public void ReturnAValidDataAccessObject()
		{
			IPeriodTypeDataAccess da = DalFactory.Instance.Get<IPeriodTypeDataAccess>();

			Assert.NotNull(da);
			Assert.IsType<PeriodTypeDataAccess>(da);
		}

		[Fact]
		public void ReturnTableData()
		{
			IPeriodTypeDataAccess da = DalFactory.Instance.Get<IPeriodTypeDataAccess>();
			IEnumerable<PeriodType> items = da.GetAll();

			Assert.NotEmpty(items);
			Assert.All(items, item => Assert.False(String.IsNullOrEmpty(item.Name)));
			Assert.All(items, item => Assert.NotEqual(0, item.PeriodTypeId));
		}
	}
}
