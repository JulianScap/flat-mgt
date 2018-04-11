using FlatManagement.Common.Exceptions;
using FlatManagement.Dal;
using FlatManagement.Dal.Impl;
using FlatManagement.Dal.Interface;
using Xunit;

namespace FlatManagement.Test.DalTestTools
{
	public class DataAccessLayerShould
	{
		[Fact]
		public void HasASingleton()
		{
			DalFactory firstInstance = DalFactory.Instance;
			DalFactory secondInstance = DalFactory.Instance;

			Assert.NotNull(firstInstance);
			Assert.Same(firstInstance, secondInstance);
		}

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
