using FlatManagement.Bll.Tools;
using FlatManagement.Common.Dto;
using FlatManagement.Dto.Entities;

namespace FlatManagement.Bll.Interface
{
	public interface IPeriodTypeModel : IReadOnlyModel<PeriodType>, IDtoList<PeriodType>
	{
	}
}
