using FlatManagement.Bll.Interface;
using FlatManagement.Common.Services;
using FlatManagement.Common.Validation;
using FlatManagement.WebApi.Controllers.Base;
using FlatManagement.WebApi.Model;
using FlatManagement.WebApi.Security;
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
			var loginRequest = GetBody<LoginRequest>();
			IAccountModel account = ServiceLocator.Instance.GetService<IAccountModel>();
			account.GetByLogin(loginRequest.Login);

			ValidationResult result = account.CheckPassword(loginRequest.PasswordHash);


			if (result.IsValid)
			{
				string token = TokenHelper.GetNewToken(loginRequest.Login, "user");

				Response.Cookies.Append("token", token);
			}

			return Json(result);
		}
	}
}
