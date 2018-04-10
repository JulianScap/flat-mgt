using FlatManagement.Common.Dto;
using FlatManagement.Dto.Entities;
using FlatManagement.Dto.Interface;

namespace FlatManagement.Bll.Interface
{
	public interface IPeriodTypeModel : IModel<PeriodType>, IDtoList<PeriodType>, IPeriodType
	{
	}
}
