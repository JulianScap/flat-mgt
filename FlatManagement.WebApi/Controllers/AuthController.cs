using FlatManagement.Bll.Interface;
using FlatManagement.Bll.Model;
using FlatManagement.Common.Services;
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

			CheckPasswordResult result = account.CheckPassword(loginRequest.PasswordHash);
			if (result.Success)
			{
				return Json(new LoginResult() { Error = false });
			}
			else
			{
				return Json(new LoginResult() { Error = true, Message = result.Message });
			}
		}
	}
}
