using System;
using System.Diagnostics;
using FlatManagement.Common.Dto;
using FlatManagement.Common.Validation;
using FlatManagement.Dto.Enums;

namespace FlatManagement.Dto.Entities
{
	[DebuggerDisplay("PeriodType({PeriodTypeId}::{Name})")]
	public partial class PeriodType : AbstractDto<int>, IEquatable<PeriodType>
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
			return HashCode.Compute(this.Name, this.PeriodTypeId);
		}

		public bool Equals(PeriodType other)
		{
			if (other == null)
			{
				return false;
			}
			else
			{
				return this.Name == other.Name
					&& this.PeriodTypeId == other.PeriodTypeId;
			}
		}

		private readonly string[] ids = new string[] { "PeriodTypeId" };
		private readonly string[] fields = new string[] { "Name" };
		private readonly string[] allFields = new string[] { "PeriodTypeId", "Name" };

		public override string[] IdFieldNames { get => ids; }
		public override string[] DataFieldNames { get => fields; }
		public override string[] AllFieldNames { get => allFields; }
	}
}
