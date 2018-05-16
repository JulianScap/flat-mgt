using FlatManagement.Bll.Interface;
using FlatManagement.Common.Services;
using FlatManagement.Common.Validation;
using FlatManagement.WebApi.Controllers.Base;
using FlatManagement.WebApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace FlatManagement.WebApi.Controllers
{
	public class AuthController : AbstractController
	{
		public AuthController(IConfiguration configuration) : base(configuration)
		{

		}

		[HttpPost]
		public object Login()
		{
			var loginRequest = base.GetBody<LoginRequest>();
			IAccountModel account = ServiceLocator.Instance.GetService<IAccountModel>();
			account.GetByLogin(loginRequest.Login);

			ValidationResult result = account.CheckPassword(loginRequest.PasswordHash);
			return Json(result);
		}
	}
}
