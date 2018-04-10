using System.Diagnostics;
using FlatManagement.Common.Dto;
using FlatManagement.Dto.Enums;
using FlatManagement.Dto.Interface;

namespace FlatManagement.Dto.Entities
{
	[DebuggerDisplay("PeriodType({PeriodTypeId}::{Name})")]
	public partial class PeriodType : AbstractDto<int>, IPeriodType
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
