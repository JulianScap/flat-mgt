using FlatManagement.Common.Services;
using FlatManagement.Test.Tools;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace FlatManagement.Test.Common
{
	public class ServiceLocatorShould : TestBase
	{
		public override IConfiguration GetConfiguration(string fileName = "appsettings.json")
		{
			return base.GetConfiguration("Configurations\\Services.json");
		}

		[Fact]
		public void InitialiseProperly()
		{
			IConfiguration configuration = GetConfiguration();
			ServiceLocator.Instance.SetConfiguration(configuration);
			ServiceLocator.Instance.Initialise();
		}

		[Fact]
		public void ReturnANewInstanceProperly()
		{
			IConfiguration configuration = GetConfiguration();
			ServiceLocator.Instance.SetConfiguration(configuration);

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
			IConfiguration configuration = GetConfiguration();
			ServiceLocator.Instance.SetConfiguration(configuration);

			ITestLocatorInterface2 result = ServiceLocator.Instance.GetService<ITestLocatorInterface2>();
			ITestLocatorInterface2 result2 = ServiceLocator.Instance.GetService<ITestLocatorInterface2>();

			Assert.NotNull(result);
			Assert.NotNull(result2);

			Assert.IsType<TestLocatorClass>(result);
			Assert.IsType<TestLocatorClass>(result2);

			Assert.Same(result, result2);
		}
	}
}
