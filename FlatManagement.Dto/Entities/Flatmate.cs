﻿using System;
using System.Diagnostics;
using FlatManagement.Common.Dto;
using FlatManagement.Common.Validation;
using Newtonsoft.Json;

namespace FlatManagement.Dto.Entities
{
	[DebuggerDisplay("Flatmate({FlatmateId}::{FullName})")]
	public partial class Flatmate : AbstractDto, IEquatable<Flatmate>
	{
		public int FlatmateId { get; set; }
		public int? FlatId { get; set; }
		public string FullName { get; set; }
		public string NickName { get; set; }
		public DateTime? BirthDate { get; set; }
		public bool FlatTenant { get; set; }
		public string Login { get; set; }
		[JsonIgnore]
		public string Password { get; set; }

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
					&& this.NickName == other.NickName
					&& this.BirthDate == other.BirthDate
					&& this.FlatTenant == other.FlatTenant
					&& this.Login == other.Login;
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
			return HashCode.Compute(this.FlatmateId, this.FlatId, this.FullName, this.NickName, this.BirthDate, this.FlatTenant, this.Login);
		}

		public override ValidationResult Validate()
		{
			ValidationResult = new ValidationResult();

			ValidationTool.Required(ValidationResult, this.Login, () => String.Format("The login field is mandatory"));
			ValidationTool.MaxLength(ValidationResult, this.Login, 100, () => String.Format("The login field is too long"));

			ValidationTool.Required(ValidationResult, this.FullName, () => String.Format("The full name field is mandatory"));
			ValidationTool.MaxLength(ValidationResult, this.FullName, 500, () => String.Format("The full name field is too long"));

			ValidationTool.MaxLength(ValidationResult, this.NickName, 100, () => String.Format("The nickname field is too long"));

			return ValidationResult;
		}

		private static readonly string[] ids = new string[] { "FlatmateId" };
		private static readonly TypeEnum[] idsType = new TypeEnum[] { TypeEnum.Int32 };
		private static readonly TypeEnum[] allType = new TypeEnum[] { TypeEnum.Int32, TypeEnum.Int32, TypeEnum.String, TypeEnum.String, TypeEnum.Date, TypeEnum.Boolean, TypeEnum.String, TypeEnum.String };
		private static readonly TypeEnum[] dataFieldTypes = new TypeEnum[] { TypeEnum.Int32, TypeEnum.String, TypeEnum.String, TypeEnum.Date, TypeEnum.Boolean, TypeEnum.String, TypeEnum.String };
		private static readonly string[] fields = new string[] { "FlatId", "FullName", "NickName", "BirthDate", "FlatTenant", "Login", "Password" };
		private static readonly string[] allFields = new string[] { "FlatmateId", "FlatId", "FullName", "NickName", "BirthDate", "FlatTenant", "Login", "Password" };

		public override string[] IdFieldNames { get => ids; }
		public override TypeEnum[] IdFieldTypes { get => idsType; }
		public override TypeEnum[] DataFieldTypes { get => dataFieldTypes; }
		public override TypeEnum[] AllFieldTypes { get => allType; }
		public override string[] DataFieldNames { get => fields; }
		public override string[] AllFieldNames { get => allFields; }

		public override bool IsPersisted => FlatmateId != 0;
	}
}
