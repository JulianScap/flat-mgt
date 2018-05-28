using FlatManagement.Common.WebApi;

namespace FlatManagement.Common.Dal
{
	public interface IUserInfoProvider
	{
		UserInfo GetUserInfo();
	}
}