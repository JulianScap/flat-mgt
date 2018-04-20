using System;
using System.Diagnostics;
using FlatManagement.Common.Dto;
using FlatManagement.Common.Validation;

namespace FlatManagement.Dto.Entities
{
	[DebuggerDisplay("Flat({FlatId}::{Name})")]
	public partial class Flat : AbstractDto<int>, IEquatable<Flat>
	{
		public int FlatId { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }

		public override int GetId()
		{
			return this.FlatId;
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

		private readonly string[] ids = new string[] { "FlatId" };
		private readonly string[] fields = new string[] { "Name", "Address" };
		private readonly string[] allFields = new string[] { "FlatId", "Name", "Address" };

		public override string[] IdFieldNames { get => ids; }
		public override string[] DataFieldNames { get => fields; }
		public override string[] AllFieldNames { get => allFields; }
	}
}
