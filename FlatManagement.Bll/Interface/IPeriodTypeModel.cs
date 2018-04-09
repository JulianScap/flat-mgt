using FlatManagement.Common.Dto;
using FlatManagement.Dto.Entities;
using FlatManagement.Dto.List;

namespace FlatManagement.Bll.Interface
{
	public interface IPeriodTypeModel : IModel<PeriodType, PeriodTypeDto>, IDtoList<PeriodTypeDto>
	{
	}
}
