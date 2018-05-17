using System;
using FlatManagement.Bll.Impl;
using FlatManagement.Bll.Interface;
using FlatManagement.Common.Services;
using FlatManagement.Test.Tools;
using Xunit;

namespace FlatManagement.Test.Bll
{
	public class PeriodTypeModelShould : TestBase
	{
		[Fact]
		public void ReturnAValidModelObject()
		{
			IPeriodTypeModel ptm = ServiceLocator.Instance.GetService<IPeriodTypeModel>();

			Assert.NotNull(ptm);
			Assert.IsType<PeriodTypeModel>(ptm);
		}

		[Fact]
		public void BeAbleToGetAllDbItems()
		{
			IPeriodTypeModel ptm = ServiceLocator.Instance.GetService<IPeriodTypeModel>();
			ptm.GetAll();

			Assert.NotEmpty(ptm);
			Assert.All(ptm, item => Assert.False(String.IsNullOrEmpty(item.Name)));
			Assert.All(ptm, item => Assert.NotEqual(0, item.PeriodTypeId));
		}
	}
}
