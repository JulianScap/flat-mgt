using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace FlatManagement.Web.Controllers
{
	public class HomeControler : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Error()
		{
			ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
			return View();
		}
	}
}
