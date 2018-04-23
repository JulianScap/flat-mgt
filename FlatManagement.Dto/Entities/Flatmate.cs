using System;
using System.Diagnostics;
using FlatManagement.Common.Dto;
using FlatManagement.Common.Validation;

namespace FlatManagement.Dto.Entities
{
	[DebuggerDisplay("Flatmate({FlatmateId}::{FullName})")]
	public partial class Flatmate : AbstractDto, IEquatable<Flatmate>
	{
		public int FlatmateId { get; set; }
		public int FlatId { get; set; }
		public string FullName { get; set; }
		public string Nickname { get; set; }
		public DateTime? BirthDate { get; set; }
		public bool FlatTenant { get; set; }

		public Flatmate() { }

		public Flatmate(int flatmateId)
		{
			this.FlatmateId = flatmateId;
		}

		public bool Equals(Flatmate other)
		{
			if (other == null)
			{
				return false;
			}
			else
			{
				return this.FlatmateId == other.FlatmateId
					&& this.FlatId == other.FlatId
					&& this.FullName == other.FullName
					&& this.Nickname == other.Nickname
					&& this.BirthDate == other.BirthDate
					&& this.FlatTenant == other.FlatTenant;
			}
		}

		public override bool Equals(object obj)
		{
			if (obj is Flatmate pt)
			{
				return Equals(pt);
			}

			return false;
		}

		public override int GetHashCode()
		{
			return HashCode.Compute(this.FlatmateId, this.FlatId, this.FullName, this.Nickname, this.BirthDate, this.FlatTenant);
		}

		private static readonly string[] ids = new string[] { "FlatmateId" };
		private static readonly TypeEnum[] idsType = new TypeEnum[] { TypeEnum.Int32 };
		private static readonly string[] fields = new string[] { "FlatId", "FullName", "Nickname", "BirthDate", "FlatTenant" };
		private static readonly string[] allFields = new string[] { "FlatmateId", "FlatId", "FullName", "Nickname", "BirthDate", "FlatTenant" };

		public override string[] IdFieldNames { get => ids; }
		public override TypeEnum[] IdFieldTypes { get => idsType; }
		public override string[] DataFieldNames { get => fields; }
		public override string[] AllFieldNames { get => allFields; }

		public override bool IsPersisted => FlatmateId != 0;
	}
}
