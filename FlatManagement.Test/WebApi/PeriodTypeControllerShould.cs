using System;
using FlatManagement.Bll.Interface;
using FlatManagement.Dto.Entities;
using FlatManagement.Dto.Enums;
using FlatManagement.Test.Tools;
using FlatManagement.WebApi.Controllers;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace FlatManagement.Test.WebApi
{
	public class PeriodTypeControllerShould : TestBase
	{
		[Fact]
		public void Return10ItemsOnGetAll()
		{
			IConfiguration configuration = GetConfiguration();
			PeriodTypeController ptc = new PeriodTypeController(configuration);
			IPeriodTypeModel iptm = ptc.Get();
			Assert.Equal(10, iptm.Count);
		}

		[Fact]
		public void ReturnCorrectItemOnValidGetById()
		{
			IConfiguration configuration = GetConfiguration();
			PeriodTypeController ptc = new PeriodTypeController(configuration);
			Array periodTypeIds = Enum.GetValues(typeof(PeriodTypeEnum));

			foreach (PeriodTypeEnum periodTypeId in periodTypeIds)
			{
				IPeriodTypeModel iptm = ptc.Get((int)periodTypeId);

				Assert.Equal(1, iptm.Count);
				Assert.Equal((int)periodTypeId, iptm[0].PeriodTypeId);
				Assert.Equal(periodTypeId.ToString(), iptm[0].Name);
			}
		}
	}
}
