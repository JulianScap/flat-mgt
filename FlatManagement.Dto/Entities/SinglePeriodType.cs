using FlatManagement.Common.Dto;
using FlatManagement.Dto.Enums;
using FlatManagement.Dto.Interface;

namespace FlatManagement.Dto.Entities
{
	public partial class SinglePeriodType : AbstractDto<int>, IPeriodType
	{
		public SinglePeriodType() { }

		public SinglePeriodType(PeriodTypeEnum periodTypeEnum)
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
