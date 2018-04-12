using FlatManagement.Common.Dto;

namespace FlatManagement.Dto.Entities
{
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
