using FlatManagement.Common.Exceptions;
using FlatManagement.Dal;
using FlatManagement.Test.Tools;
using Xunit;

namespace FlatManagement.Test.Dal
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
		public void ThrowAnExceptionIfImplementationNotFound()
		{
			Assert.Throws<ImplementationNotFoundException>(() => DalFactory.Instance.Get<INoImplementationDataAccess>());
		}
	}
}
