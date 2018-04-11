using FlatManagement.Common.Exceptions;
using FlatManagement.Dal.Impl;
using FlatManagement.Dal.Interface;
using FlatManagement.Test.DalTestTools;
using Xunit;

namespace FlatManagement.Dal.Test
{
	public class DalShould
	{
		[Fact]
		public void ReturnAValidDataAccessObject()
		{
			IPeriodTypeDataAccess da = DalFactory.Instance.Get<IPeriodTypeDataAccess>();

			Assert.NotNull(da);
			Assert.IsType<PeriodTypeDataAccess>(da);
		}

		[Fact]
		public void ThrowAnExceptionIfImplementationNotFound()
		{
			Assert.Throws<ImplementationNotFoundException>(() => DalFactory.Instance.Get<INoImplementationDataAccess>());
		}
	}
}