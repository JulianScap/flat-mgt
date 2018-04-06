using FlatManagement.Common.Dto;
using FlatManagement.Dto.Enums;
using FlatManagement.Dto.Interface;

namespace FlatManagement.Dto.Entities
{
	public partial class PeriodTypeDto : AbstractDto<int>, IPeriodType
	{
		public PeriodTypeDto() { }

		public PeriodTypeDto(PeriodTypeEnum periodTypeEnum)
		{
			this.PeriodTypeId = (int)periodTypeEnum;
			this.Name = periodTypeEnum.ToString();
		}

		public int PeriodTypeId { get; set; }
		public string Name { get; set; }

		public override int GetId()
		{
			return this.PeriodTypeId;
		}
	}
}
