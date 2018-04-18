using Microsoft.Extensions.Configuration;

namespace FlatManagement.Test.Tools
{
	public class TestBase
	{
		public virtual IConfiguration GetConfiguration(string fileName = "appsettings.json")
		{
			ConfigurationBuilder builder = new ConfigurationBuilder();
			builder.AddJsonFile(fileName);
			return builder.Build();
		}
	}
}
