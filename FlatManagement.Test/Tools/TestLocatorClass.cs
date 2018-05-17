using Microsoft.Extensions.Configuration;

namespace FlatManagement.Test.Tools
{
	class TestLocatorClass : ITestLocatorInterface, ITestLocatorInterface2
	{
		public TestLocatorClass(IConfiguration configuration)
		{

		}
	}
}
