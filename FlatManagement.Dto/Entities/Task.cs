using System;
using FlatManagement.Common.Dto;
using FlatManagement.Common.Validation;
using FlatManagement.Dto.Enums;

namespace FlatManagement.Dto.Entities
{
	public partial class Task : AbstractDto, IEquatable<Task>
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

		public override bool Equals(object obj)
		{
			if (obj is PeriodType pt)
			{
				return Equals(pt);
			}

			return false;
		}

		public override int GetHashCode()
		{
			return HashCode.Compute(this.TaskId, this.Name, this.Description, this.DateStart, this.PeriodTypeId);
		}

		public bool Equals(Task other)
		{
			if (other == null)
			{
				return false;
			}
			else
			{
				return this.TaskId == other.TaskId
					&& this.Name == other.Name
					&& this.Description == other.Description
					&& this.DateStart == other.DateStart
					&& this.PeriodTypeId == other.PeriodTypeId;
			}
		}

		private readonly string[] ids = new string[] { "TaskId" };
		private readonly TypeEnum[] idsType = new TypeEnum[] { TypeEnum.Int32 };
		private readonly string[] fields = new string[] { "Name", "Description", "DateStart", "PeriodTypeId" };
		private readonly string[] allFields = new string[] { "TaskId", "Name", "Description", "DateStart", "PeriodTypeId" };

		public override string[] IdFieldNames { get => ids; }
		public override TypeEnum[] IdFieldTypes { get => idsType; }
		public override string[] DataFieldNames { get => fields; }
		public override string[] AllFieldNames { get => allFields; }

		public override bool IsPersisted => TaskId != 0;
	}
}
