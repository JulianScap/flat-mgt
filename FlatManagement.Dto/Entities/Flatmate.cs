using System;
using FlatManagement.Common.Dto;

namespace FlatManagement.Dto.Entities
{
	public partial class Flatmate : AbstractDto<int>
	{
		public int FlatmateId { get; set; }
		public int FlatId { get; set; }
		public string FullName { get; set; }
		public string Nickname { get; set; }
		public DateTime? BirthDate { get; set; }
		public bool FlatTenant { get; set; }

		public override int GetId()
		{
			return this.FlatmateId;
		}
	}
}
