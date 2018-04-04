using System;
using FlatManagement.Common.Dto;
using FlatManagement.Dto.Enums;

namespace FlatManagement.Dto.Entities
{
	public partial class Task : AbstractDto<int>
	{
		public int TaskId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public DateTime? DateStart { get; set; }
		public int? PeriodTypeId { get; set; }

		public PeriodTypeEnum? PeriodTypeIdAsEnum
		{
			get
			{
				if (PeriodTypeId.HasValue)
				{
					return (PeriodTypeEnum)PeriodTypeId.Value;
				}
				else
				{
					return null;
				}
				
			}
			set
			{
				if (value.HasValue)
				{
					PeriodTypeId = (int)value.Value;
				}
				else
				{
					PeriodTypeId = null;
				}
			}
		}

		public override int GetId()
		{
			return this.TaskId;
		}
	}
}
