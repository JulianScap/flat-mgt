using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace FlatManagement.WebApi.Controllers.Base
{
	[Produces("application/json")]
	[Route("api/[controller]")]
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

		internal T GetBody<T>()
		{
			string body = GetBodyAsString();
			return JsonConvert.DeserializeObject<T>(body);
		}
	}
}
