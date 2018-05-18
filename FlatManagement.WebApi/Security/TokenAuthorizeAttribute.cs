using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FlatManagement.WebApi.Security
{
	public class TokenAuthorizeAttribute : Attribute, IAuthorizationFilter, IOrderedFilter
	{
		public int Order { get => 0; }

		public void OnAuthorization(AuthorizationFilterContext context)
		{
			string token = context.HttpContext.Request.Headers["token"].ToString();

			if (!TokenHelper.CheckToken(token))
			{
				context.Result = new UnauthorizedResult();
			}
		}
	}
}
