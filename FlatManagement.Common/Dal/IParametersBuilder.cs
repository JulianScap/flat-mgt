using FlatManagement.Common.Dto;
using FlatManagement.Common.WebApi;

namespace FlatManagement.Common.Dal
{
	public interface IParametersBuilder
	{
		Parameter[] BuildIdParameters(IDto item);
		Parameter[] BuildParametersFromDto(IDto item, bool update);
		Parameter[] BuildIdOutParameters(IDto item);
		Parameter[] BuildUserParameters(UserInfo userInfo);
	}
}
