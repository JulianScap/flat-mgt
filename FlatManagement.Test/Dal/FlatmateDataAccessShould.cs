using FlatManagement.Common.Services;
using FlatManagement.Dal.Impl;
using FlatManagement.Dal.Interface;
using FlatManagement.Test.Tools;
using Xunit;

namespace FlatManagement.Test.Dal
{
	public class FlatmateDataAccessShould : TestBase
	{
		[Fact]
		public void ReturnAValidDataAccessObject()
		{
			IFlatmateDataAccess da = ServiceLocator.Instance.GetService<IFlatmateDataAccess>();

			Assert.NotNull(da);
			Assert.IsType<FlatmateDataAccess>(da);
		}
	}
}
