using FlatManagement.Dto.Entities;
using Xunit;

namespace FlatManagement.Test.Common
{
	public class FlatShould
	{
		[Theory]
		[InlineData(17, "19A", "19A Mount Eden Road")]
		[InlineData(1, "4E", "4E MacAulay Street")]
		public void HaveSameHashCodeForEqualObjects(int id, string name, string address)
		{
			Flat flat1 = new Flat() { FlatId = id, Name = name, Address = address };
			Flat flat2 = new Flat() { FlatId = id, Name = name, Address = address };

			Assert.Equal(flat1, flat2);
			Assert.Equal(flat1.GetHashCode(), flat2.GetHashCode());
		}

		[Theory]
		[InlineData(17, "19A", "19A Mount Eden Road")]
		[InlineData(1, "4E", "4E MacAulay Street")]
		public void HaveDifferentHashCodeForDifferentObjects(int id, string name, string address)
		{
			Flat flat1 = new Flat() { FlatId = id, Name = name, Address = address };
			Flat flat2 = new Flat() { FlatId = id, Name = name, Address = address + "." };

			Assert.NotEqual(flat1, flat2);
			Assert.NotEqual(flat1.GetHashCode(), flat2.GetHashCode());
		}
	}
}
