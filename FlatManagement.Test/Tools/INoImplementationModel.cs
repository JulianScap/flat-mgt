using FlatManagement.Bll.Tools;
using FlatManagement.Common.Dto;

namespace FlatManagement.Test.Tools
{
	public interface INoImplementationModel : IModel<FakeDto>, IDtoList<FakeDto>, IFakeDto
	{
	}
}
