using FlatManagement.Common.Dto;

namespace FlatManagement.Dto.Interface
{
	public interface IPeriodType : IDto
	{
		int PeriodTypeId { get; set; }
		string Name { get; set; }
	}
}
