using FlatManagement.Common.Services;
using FlatManagement.Common.WebApi;
using Microsoft.Extensions.Configuration;

namespace FlatManagement.Test.Tools
{
	public class TestBase
	{
		public TestBase()
		{
			ServiceLocator.Instance.SetConfiguration(GetConfiguration());
			ServiceLocator.Instance.AddService<UserInfo>(() => new UserInfo() { Login = "Julian" });
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
