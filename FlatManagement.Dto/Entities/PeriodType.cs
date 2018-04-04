using FlatManagement.Common.Dto;
using FlatManagement.Dto.Enums;

namespace FlatManagement.Dto.Entities
{
	public partial class PeriodType : AbstractDto<int>
	{
		public PeriodType() { }

		public PeriodType(PeriodTypeEnum periodTypeEnum)
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
