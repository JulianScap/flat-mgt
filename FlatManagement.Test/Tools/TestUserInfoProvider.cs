using FlatManagement.Common.Dal;
using FlatManagement.Common.WebApi;

namespace FlatManagement.Test.Tools
{
	public class TestUserInfoProvider : IUserInfoProvider
	{
		public UserInfo GetUserInfo()
		{
			return new UserInfo
			{
				Login = "Julian"
			};
		}
	}
}
