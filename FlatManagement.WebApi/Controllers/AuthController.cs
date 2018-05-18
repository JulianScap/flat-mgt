using FlatManagement.Bll.Interface;
using FlatManagement.Common.Services;
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

			LoginResult result = new LoginResult();
			result.ValidationResult = account.CheckPassword(loginRequest.PasswordHash);

			if (result.ValidationResult.IsValid)
			{
				result.Token = TokenHelper.GetNewToken(account[0]);
			}

			return Json(result);
		}
	}
}
