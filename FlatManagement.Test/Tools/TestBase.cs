using Microsoft.Extensions.Configuration;

namespace FlatManagement.Test.Tools
{
	public class TestBase
	{
		public TestBase()
		{
		}

		public IConfiguration GetConfiguration()
		{
			ConfigurationBuilder builder = new ConfigurationBuilder();

			builder.AddJsonFile("Configurations\\appsettings.json");
			builder.AddJsonFile("Configurations\\Services.json");
			builder.AddJsonFile("Configurations\\Security.json");

			return builder.Build();
		}
	}
}
