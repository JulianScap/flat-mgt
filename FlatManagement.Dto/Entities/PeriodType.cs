using System;
using System.Diagnostics;
using FlatManagement.Common.Dto;
using FlatManagement.Common.Validation;
using FlatManagement.Dto.Enums;

namespace FlatManagement.Dto.Entities
{
	[DebuggerDisplay("PeriodType({PeriodTypeId}::{Name})")]
	public partial class PeriodType : AbstractDto, IEquatable<PeriodType>, IEquatable<PeriodTypeEnum>
	{
		public PeriodType() { }

		public PeriodType(int periodTypeId) : this((PeriodTypeEnum)periodTypeId)
		{
		}

		public PeriodType(PeriodTypeEnum periodTypeEnum)
		{
			this.PeriodTypeId = (int)periodTypeEnum;
			this.Name = periodTypeEnum.ToString();
		}

		public int PeriodTypeId { get; set; }
		public string Name { get; set; }

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

		public bool Equals(PeriodTypeEnum other)
		{
			return this.PeriodTypeId == (int)other;
		}

		public override void Validate()
		{
			ValidationResult = new ValidationResult();
		}

		private static readonly string[] ids = new string[] { "PeriodTypeId" };
		private static readonly TypeEnum[] idsType = new TypeEnum[] { TypeEnum.Int32 };
		private static readonly TypeEnum[] allType = new TypeEnum[] { TypeEnum.Int32, TypeEnum.String };
		private static readonly TypeEnum[] dataFieldTypes = new TypeEnum[] { TypeEnum.String };
		private static readonly string[] fields = new string[] { "Name" };
		private static readonly string[] allFields = new string[] { "PeriodTypeId", "Name" };

		public override string[] IdFieldNames { get => ids; }
		public override TypeEnum[] IdFieldTypes { get => idsType; }
		public override TypeEnum[] DataFieldTypes { get => dataFieldTypes; }
		public override TypeEnum[] AllFieldTypes { get => allType; }
		public override string[] DataFieldNames { get => fields; }
		public override string[] AllFieldNames { get => allFields; }

		public override bool IsPersisted => PeriodTypeId != 0;

		#region explicit operator
		public static explicit operator PeriodType(PeriodTypeEnum periodTypeEnum)
		{
			return new PeriodType(periodTypeEnum);
		}

		public static explicit operator PeriodTypeEnum(PeriodType periodType)
		{
			if (periodType == null)
			{
				throw new ArgumentNullException("periodType");
			}
			else if (!Enum.IsDefined(typeof(PeriodTypeEnum), periodType.PeriodTypeId))
			{
				throw new ArgumentException($"Invalid period type {periodType.PeriodTypeId}", "periodType");
			}
			else
			{
				return (PeriodTypeEnum)periodType.PeriodTypeId;
			}
		}
		#endregion
	}
}
