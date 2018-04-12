using Microsoft.Extensions.Configuration;

namespace FlatManagement.Test.Tools
{
	public class TestBase
	{
		public virtual IConfiguration GetConfiguration()
		{
			ConfigurationBuilder bob = new ConfigurationBuilder();

			bob.AddJsonFile(@"appsettings.json");

			return bob.Build();
		}
	}
}
