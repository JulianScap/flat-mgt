using System;
using System.Diagnostics;
using FlatManagement.Common.Dto;
using FlatManagement.Common.Validation;

namespace FlatManagement.Dto.Entities
{
	[DebuggerDisplay("Flat({FlatId}::{Name})")]
	public partial class Flat : AbstractDto, IEquatable<Flat>
	{
		public int FlatId { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }

		public Flat()
		{

		}

		public Flat(int flatId)
		{
			this.FlatId = flatId;
		}

		public override bool Equals(object obj)
		{
			if (obj is Flat pt)
			{
				return Equals(pt);
			}

			return false;
		}

		public override int GetHashCode()
		{
			return HashCode.Compute(this.Name, this.FlatId, this.Address);
		}

		public bool Equals(Flat other)
		{
			if (other == null)
			{
				return false;
			}
			else
			{
				return this.Name == other.Name
					&& this.Address == other.Address
					&& this.FlatId == other.FlatId;
			}
		}

		public override void Validate()
		{
			ValidationResult = new ValidationResult();

			ValidationTool.Required(ValidationResult, this.Name, () => String.Format("The name field is mandatory"));
			ValidationTool.MaxLength(ValidationResult, this.Name, 200, () => String.Format("The name field is too long"));
			ValidationTool.MaxLength(ValidationResult, this.Address, 1000, () => String.Format("The address field is too long"));
		}

		private static readonly string[] ids = new string[] { "FlatId" };
		private static readonly TypeEnum[] idsType = new TypeEnum[] { TypeEnum.Int32 };
		private static readonly TypeEnum[] allType = new TypeEnum[] { TypeEnum.Int32, TypeEnum.String, TypeEnum.String };
		private static readonly TypeEnum[] dataFieldTypes = new TypeEnum[] { TypeEnum.String, TypeEnum.String };
		private static readonly string[] fields = new string[] { "Name", "Address" };
		private static readonly string[] allFields = new string[] { "FlatId", "Name", "Address" };

		public override string[] IdFieldNames { get => ids; }
		public override TypeEnum[] IdFieldTypes { get => idsType; }
		public override TypeEnum[] DataFieldTypes { get => dataFieldTypes; }
		public override TypeEnum[] AllFieldTypes { get => allType; }
		public override string[] DataFieldNames { get => fields; }
		public override string[] AllFieldNames { get => allFields; }

		public override bool IsPersisted => FlatId != 0;
	}
}
