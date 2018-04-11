using FlatManagement.Dal.Interface;

namespace FlatManagement.Test.DalTestTools
{
	interface INoImplementationDataAccess : IDataAccess<FakeDto>
	{
    }
}
