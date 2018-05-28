using System.Transactions;
using FlatManagement.Bll.Interface;
using FlatManagement.Common.Transaction;
using FlatManagement.Common.Validation;
using FlatManagement.Dto.Entities;
using FlatManagement.WebApi.Controllers.Base;
using FlatManagement.WebApi.Model;
using FlatManagement.WebApi.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace FlatManagement.WebApi.Controllers
{
	public class AuthController : AbstractController
	{
		private readonly IFlatmateService flatmateService;
		private readonly IFlatService flatService;

		public AuthController(IFlatService flatService, IFlatmateService flatmateService, IConfiguration configuration) : base(configuration)
		{
			this.flatService = flatService;
			this.flatmateService = flatmateService;
		}

		[HttpPost]
		public object Login()
		{
			var loginRequest = GetBody<LoginRequest>();
			var flatmate = flatmateService.GetByLogin(loginRequest.Login);

			LoginResult result = new LoginResult()
			{
				ValidationResult = flatmateService.CheckPassword(flatmate, loginRequest.PasswordHash)
			};

			if (result.ValidationResult.IsValid)
			{
				result.Token = TokenHelper.GetNewToken(flatmate);
			}

			return Json(result);
		}

		[HttpPut]
		public object Create()
		{
			ValidationResult result = new ValidationResult();
			AuthCreateRequest request = GetBody<AuthCreateRequest>();

			using (TransactionScope ts = TransactionUtil.New())
			{
				result.Add(flatService.Save(request.Flat));

				if (result.IsValid)
				{
					request.Flatmate.FlatId = request.Flat.FlatId;
					result.Add(flatmateService.Save(request.Flatmate));

					if (result.IsValid)
					{
						request.Flatmate.Password = request.Password;
						flatmateService.PreparePassword(request.Flatmate);
						flatmateService.SavePassword(request.Flatmate);

						ts.Complete();
					}
				}
			}

			return Json(result);
		}
	}
}
