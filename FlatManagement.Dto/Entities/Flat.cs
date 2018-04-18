using FlatManagement.Common.Dto;
using FlatManagement.Common.Dto.Attributes;

namespace FlatManagement.Dto.Entities
{
	[IdPropertyName("FlatId")]
	public partial class Flat : AbstractDto<int>
	{
		public int FlatId { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }

		public override int GetId()
		{
			return this.FlatId;
		}
	}
}
