using System.Transactions;
using FlatManagement.Bll.Interface;
using FlatManagement.Common.Services;
using FlatManagement.Common.Transaction;
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
			IFlatmateModel flatmate = ServiceLocator.Instance.GetService<IFlatmateModel>();
			flatmate.GetByLogin(loginRequest.Login);

			LoginResult result = new LoginResult()
			{
				ValidationResult = flatmate.CheckPassword(loginRequest.PasswordHash)
			};

			if (result.ValidationResult.IsValid)
			{
				result.Token = TokenHelper.GetNewToken(flatmate[0]);
			}

			return Json(result);
		}

		[HttpPut]
		public object Create()
		{
			ValidationResult result = new ValidationResult();
			AuthCreateRequest request = GetBody<AuthCreateRequest>();
			IFlatModel flat = ServiceLocator.Instance.GetService<IFlatModel>();
			IFlatmateModel flatmate = ServiceLocator.Instance.GetService<IFlatmateModel>();

			using (TransactionScope ts = TransactionUtil.New())
			{
				flat.Add(request.Flat);
				result.Add(flat.PersistAll());

				if (result.IsValid)
				{
					request.Flatmate.FlatId = request.Flat.FlatId;
					flatmate.Add(request.Flatmate);
					result.Add(flatmate.PersistAll());
					if (result.IsValid)
					{
						request.Flatmate.Password = request.Password;
						flatmate.PreparePassword();
						flatmate.SavePassword();

						ts.Complete();
					}
				}
			}

			return Json(result);
		}
	}
}
