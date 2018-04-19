﻿using FlatManagement.Common.Services;
using Microsoft.Extensions.Configuration;

namespace FlatManagement.Test.Tools
{
	public class TestBase
	{
		public TestBase()
		{
			ServiceLocator.Instance.SetConfiguration(GetConfiguration());
		}

		public IConfiguration GetConfiguration()
		{
			ConfigurationBuilder builder = new ConfigurationBuilder();

			builder.AddJsonFile("Configurations\\appsettings.json");
			builder.AddJsonFile("Configurations\\Services.json");

			return builder.Build();
		}
	}
}
