using FlatManagement.Common.Services;
using FlatManagement.Test.Tools;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace FlatManagement.Test.Common
{
	public class ServiceLocatorShould : TestBase
	{
		[Fact]
		public void InitialiseProperly()
		{
			IConfiguration configuration = base.GetConfiguration();
			ServiceLocator.Instance.SetConfiguration(configuration);
			ServiceLocator.Instance.Initialise();
		}

		[Fact]
		public void ReturnAnInstanceProperly()
		{
			IConfiguration configuration = base.GetConfiguration();
			ServiceLocator.Instance.SetConfiguration(configuration);

			ITestLocatorInterface result = ServiceLocator.Instance.GetService<ITestLocatorInterface>();

			Assert.NotNull(result);
			Assert.IsType<TestLocatorClass>(result);
		}
	}
}
