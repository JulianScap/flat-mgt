using FlatManagement.Common.Bll;
using FlatManagement.Common.Dto;
using FlatManagement.Dto.Entities;

namespace FlatManagement.Bll.Interface
{
	public interface IFlatmateModel : IModel<Flatmate>, IDtoList<Flatmate>
	{
		void GetByNameAndFlatName(string nickname, string flatName);
	}
}
