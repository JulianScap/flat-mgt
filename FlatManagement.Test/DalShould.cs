using System.Collections.Generic;
using FlatManagement.Dal.Interface;
using FlatManagement.Dto.Entities;
using Xunit;

namespace FlatManagement.Dal.Test
{
	public class DalTest
	{
		[Fact]
		public void Test1()
		{
			IPeriodTypeDataAccess da = DalFactory.Instance.Get<IPeriodTypeDataAccess>();
			IEnumerable<PeriodType> result = da.GetAll();
			Assert.NotEmpty(result);
		}
	}
}
