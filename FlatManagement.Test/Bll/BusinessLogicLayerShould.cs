using FlatManagement.Bll;
using FlatManagement.Common.Exceptions;
using FlatManagement.Test.Tools;
using Xunit;

namespace FlatManagement.Test.Bll
{
	public class BusinessLogicLayerShould
	{
		[Fact]
		public void HasASingleton()
		{
			BllFactory firstInstance = BllFactory.Instance;
			BllFactory secondInstance = BllFactory.Instance;

			Assert.NotNull(firstInstance);
			Assert.Same(firstInstance, secondInstance);
		}

		[Fact]
		public void ThrowAnExceptionIfImplementationNotFound()
		{
			Assert.Throws<ImplementationNotFoundException>(() => BllFactory.Instance.Get<INoImplementationModel>());
		}
	}
}
