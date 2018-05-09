using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace FlatManagement.WebApi.Controllers.Base
{
	public class AbstractController : Controller
	{
		protected IConfiguration configuration;

		protected AbstractController(IConfiguration configuration)
		{
			this.configuration = configuration;
		}

		internal string GetBodyAsString()
		{
			using (StreamReader reader = new StreamReader(this.Request.Body))
			{
				return reader.ReadToEnd();
			}
		}
	}
}
