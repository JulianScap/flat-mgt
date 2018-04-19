using FlatManagement.Common.Exceptions;
using FlatManagement.Common.Services;
using FlatManagement.Test.Tools;
using Xunit;

namespace FlatManagement.Test.Common
{
	public class ServiceLocatorShould : TestBase
	{
		[Fact]
		public void BeASingleton()
		{
			ServiceLocator firstInstance = ServiceLocator.Instance;
			ServiceLocator secondInstance = ServiceLocator.Instance;

			Assert.NotNull(firstInstance);
			Assert.Same(firstInstance, secondInstance);
		}

		[Fact]
		public void InitialiseProperly()
		{
			ServiceLocator.Instance.Initialise();
		}

		[Fact]
		public void ReturnANewInstanceProperly()
		{
			ITestLocatorInterface result = ServiceLocator.Instance.GetService<ITestLocatorInterface>();
			ITestLocatorInterface result2 = ServiceLocator.Instance.GetService<ITestLocatorInterface>();

			Assert.NotNull(result);
			Assert.NotNull(result2);

			Assert.IsType<TestLocatorClass>(result);
			Assert.IsType<TestLocatorClass>(result2);

			Assert.NotSame(result, result2);
		}

		[Fact]
		public void ReturnSingleton()
		{
			ITestLocatorInterface2 result = ServiceLocator.Instance.GetService<ITestLocatorInterface2>();
			ITestLocatorInterface2 result2 = ServiceLocator.Instance.GetService<ITestLocatorInterface2>();

			Assert.NotNull(result);
			Assert.NotNull(result2);

			Assert.IsType<TestLocatorClass>(result);
			Assert.IsType<TestLocatorClass>(result2);

			Assert.Same(result, result2);
		}

		[Fact]
		public void ThrowIfNoImplementationCanBeFound()
		{
			Assert.Throws<ServiceNotFoundException>(() => ServiceLocator.Instance.GetService<INoImplementationModel>());
		}
	}
}
