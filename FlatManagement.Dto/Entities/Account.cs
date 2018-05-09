using System;
using System.Diagnostics;
using FlatManagement.Common.Dto;
using FlatManagement.Common.Validation;

namespace FlatManagement.Dto.Entities
{
	[DebuggerDisplay("Account({AccountId}::{Login})")]
	public partial class Account : AbstractDto, IEquatable<Account>
	{
		public int AccountId { get; set; }
		public string Login { get; set; }
		public string Password { get; set; }

		public Account()
		{

		}

		public Account(int accountId)
		{
			this.AccountId = accountId;
		}

		public override bool Equals(object obj)
		{
			if (obj is Account account)
			{
				return Equals(account);
			}

			return false;
		}

		public override int GetHashCode()
		{
			return HashCode.Compute(this.Login, this.AccountId, this.Password);
		}

		public bool Equals(Account other)
		{
			if (other == null)
			{
				return false;
			}
			else
			{
				return this.Login == other.Login
					&& this.Password == other.Password
					&& this.AccountId == other.AccountId;
			}
		}

		private static readonly string[] ids = new string[] { "AccountId" };
		private static readonly TypeEnum[] idsType = new TypeEnum[] { TypeEnum.Int32 };
		private static readonly string[] fields = new string[] { "Login", "Password" };
		private static readonly string[] allFields = new string[] { "AccountId", "Login", "Password" };

		public override string[] IdFieldNames { get => ids; }
		public override TypeEnum[] IdFieldTypes { get => idsType; }
		public override string[] DataFieldNames { get => fields; }
		public override string[] AllFieldNames { get => allFields; }

		public override bool IsPersisted => AccountId != 0;
	}
}
