using FlatManagement.Bll.Interface;
using FlatManagement.Common.Dto;

namespace FlatManagement.Test.Tools
{
	public interface INoImplementationModel : IModel<FakeDto>, IDtoList<FakeDto>, IFakeDto
	{
	}
}
