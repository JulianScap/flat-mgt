using FlatManagement.Dal.Interface;
using FlatManagement.Common.Dal;

namespace FlatManagement.Test.Tools
{
	interface INoImplementationDataAccess : IDataAccess<FakeDto>
	{
	}
}
