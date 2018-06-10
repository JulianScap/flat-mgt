using System;
using FlatManagement.Common.Dal;
using FlatManagement.Common.WebApi;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace FlatManagement.WebApi.Security
{
	public class UserInfoProvider : IUserInfoProvider
	{
		private readonly IServiceProvider serviceProvider;

		public UserInfoProvider(IServiceProvider serviceProvider)
		{
			this.serviceProvider = serviceProvider;
		}

		public UserInfo GetUserInfo()
		{
			IHttpContextAccessor accessor = serviceProvider.GetService<IHttpContextAccessor>();
			return accessor.HttpContext.Items["token"] as UserInfo;
		}
	}
}
