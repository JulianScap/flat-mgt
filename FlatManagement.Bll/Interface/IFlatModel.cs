using FlatManagement.Common.Bll;
using FlatManagement.Common.Dto;
using FlatManagement.Dto.Entities;

namespace FlatManagement.Bll.Interface
{
	public interface IFlatModel : IModel<Flat>, IDtoList<Flat>
	{
	}
}
