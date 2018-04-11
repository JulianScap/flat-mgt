using FlatManagement.Dal.Interface;

namespace FlatManagement.Test.Tools
{
	interface INoImplementationDataAccess : IDataAccess<FakeDto>
	{
	}
}
