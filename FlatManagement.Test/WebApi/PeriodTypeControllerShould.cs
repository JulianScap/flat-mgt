using System;
using FlatManagement.Bll.Interface;
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

		//[Fact]
		//public void ReturnCorrectItemOnValidGetById()
		//{
		//	IConfiguration configuration = GetConfiguration();
		//	PeriodTypeController ptc = new PeriodTypeController(configuration);
		//	Array periodTypeIds = Enum.GetValues(typeof(PeriodTypeEnum));

		//	foreach (int periodTypeId in periodTypeIds)
		//	{
		//		IPeriodTypeModel iptm = ptc.Get(periodTypeId);

		//		Assert.Equal(1, iptm.Count);
		//		Assert.Equal(periodTypeId, iptm[0].PeriodTypeId);
		//		Assert.Equal(((PeriodTypeEnum)periodTypeId).ToString(), iptm[0].Name);
		//	}
		//}
	}
}
