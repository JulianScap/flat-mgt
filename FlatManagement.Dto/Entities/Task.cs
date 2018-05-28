using System;
using FlatManagement.Common.Dto;
using FlatManagement.Common.Validation;
using FlatManagement.Dto.Enums;
using Newtonsoft.Json;

namespace FlatManagement.Dto.Entities
{
	public partial class Task : AbstractDto, IEquatable<Task>
	{
		public int TaskId { get; set; }
		public int FlatId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public DateTime? DateStart { get; set; }
		public int? PeriodTypeId { get; set; }

		public Task() { }

		public Task(int taskId)
		{
			this.TaskId = taskId;
		}

		[JsonIgnore]
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
			return HashCode.Compute(this.TaskId, this.FlatId, this.Name, this.Description, this.DateStart, this.PeriodTypeId);
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
					&& this.FlatId == other.FlatId
					&& this.Name == other.Name
					&& this.Description == other.Description
					&& this.DateStart == other.DateStart
					&& this.PeriodTypeId == other.PeriodTypeId;
			}
		}

		public override ValidationResult Validate()
		{
			ValidationResult = new ValidationResult();

			ValidationTool.Required(ValidationResult, this.Name, () => String.Format("The name field is mandatory"));
			ValidationTool.MaxLength(ValidationResult, this.Name, 100, () => String.Format("The name field is too long"));
			ValidationTool.Required(ValidationResult, this.Description, () => String.Format("The description field is mandatory"));
			ValidationTool.MaxLength(ValidationResult, this.Description, 1000, () => String.Format("The description field is too long"));

			return ValidationResult;
		}

		private static readonly string[] ids = new string[] { "TaskId" };
		private static readonly TypeEnum[] idsType = new TypeEnum[] { TypeEnum.Int32 };
		private static readonly TypeEnum[] allType = new TypeEnum[] { TypeEnum.Int32, TypeEnum.String, TypeEnum.Int32, TypeEnum.String, TypeEnum.Date, TypeEnum.Int32 };
		private static readonly TypeEnum[] dataFieldTypes = new TypeEnum[] { TypeEnum.String, TypeEnum.Int32, TypeEnum.String, TypeEnum.Date, TypeEnum.Int32 };
		private static readonly string[] fields = new string[] { "Name", "FlatId", "Description", "DateStart", "PeriodTypeId" };
		private static readonly string[] allFields = new string[] { "TaskId", "Name", "FlatId", "Description", "DateStart", "PeriodTypeId" };

		public override string[] IdFieldNames { get => ids; }
		public override TypeEnum[] IdFieldTypes { get => idsType; }
		public override TypeEnum[] DataFieldTypes { get => dataFieldTypes; }
		public override TypeEnum[] AllFieldTypes { get => allType; }
		public override string[] DataFieldNames { get => fields; }
		public override string[] AllFieldNames { get => allFields; }

		public override bool IsPersisted => TaskId != 0;
	}
}
