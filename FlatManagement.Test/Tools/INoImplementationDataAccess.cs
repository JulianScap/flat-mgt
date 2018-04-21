using FlatManagement.Dal.Interface;
using FlatManagement.Dal.Tools;

namespace FlatManagement.Test.Tools
{
	interface INoImplementationDataAccess : IDataAccess<FakeDto>
	{
	}
}
