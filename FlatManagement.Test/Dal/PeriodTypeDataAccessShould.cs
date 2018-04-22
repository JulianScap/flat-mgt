using System;
using System.Collections.Generic;
using FlatManagement.Common.Exceptions;
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
			IPeriodTypeDataAccess da = ServiceLocator.Instance.GetService<IPeriodTypeDataAccess>();

			Assert.NotNull(da);
			Assert.IsType<PeriodTypeDataAccess>(da);
		}

		[Fact]
		public void ReturnAllRows()
		{
			IPeriodTypeDataAccess da = ServiceLocator.Instance.GetService<IPeriodTypeDataAccess>();
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
			IPeriodTypeDataAccess da = ServiceLocator.Instance.GetService<IPeriodTypeDataAccess>();
			PeriodType periodType = da.GetById(periodTypeId);
			Assert.NotNull(periodType);
			Assert.Equal(periodTypeId, periodType.PeriodTypeId);
		}

		[Fact]
		public void FailOnDelete()
		{
			IPeriodTypeDataAccess da = ServiceLocator.Instance.GetService<IPeriodTypeDataAccess>();
			PeriodType periodType = da.GetById(1);

			Assert.Throws<DisabledOperationException>(() => da.Delete(periodType));
		}

		[Fact]
		public void FailOnUpdate()
		{
			IPeriodTypeDataAccess da = ServiceLocator.Instance.GetService<IPeriodTypeDataAccess>();
			PeriodType periodType = da.GetById(1);
			periodType.Name = "new name";

			Assert.Throws<DisabledOperationException>(() => da.Update(periodType));
		}

		[Fact]
		public void FailOnInsert()
		{
			IPeriodTypeDataAccess da = ServiceLocator.Instance.GetService<IPeriodTypeDataAccess>();

			Assert.Throws<DisabledOperationException>(() => da.Insert(new PeriodType() { Name = "new period type" }));
		}
	}
}
