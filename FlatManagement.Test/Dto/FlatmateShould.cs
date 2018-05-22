using System;
using FlatManagement.Dto.Entities;
using Xunit;

namespace FlatManagement.Test.Common
{
	public class FlatmateShould
	{
		[Theory]
		[InlineData(17, 23, "JAD", "Julian Adler", true)]
		[InlineData(1, 232, "SOE", "Someone Else", false)]
		public void HaveSameHashCodeForEqualObjects(int id, int flatmateId, string nickname, string fullname, bool isFlatTenant)
		{
			Flatmate flatmate1 = new Flatmate() { FlatId = id, BirthDate = DateTime.Today, FlatmateId = flatmateId, NickName = nickname, FullName = fullname, FlatTenant = isFlatTenant };
			Flatmate flatmate2 = new Flatmate() { FlatId = id, BirthDate = DateTime.Today, FlatmateId = flatmateId, NickName = nickname, FullName = fullname, FlatTenant = isFlatTenant };

			Assert.Equal(flatmate1, flatmate2);
			Assert.Equal(flatmate1.GetHashCode(), flatmate2.GetHashCode());
		}

		[Theory]
		[InlineData(17, 23, "JAD", "Julian Adler", true)]
		[InlineData(1, 232, "SOE", "Someone Else", false)]
		public void HaveDifferentHashCodeForDifferentObjects(int id, int flatmateId, string nickname, string fullname, bool isFlatTenant)
		{
			Flatmate flatmate1 = new Flatmate() { FlatId = id, BirthDate = DateTime.Today, FlatmateId = flatmateId, NickName = nickname, FullName = fullname, FlatTenant = isFlatTenant };
			Flatmate flatmate2 = new Flatmate() { FlatId = id, BirthDate = DateTime.Today, FlatmateId = flatmateId, NickName = nickname, FullName = fullname, FlatTenant = !isFlatTenant };

			Assert.NotEqual(flatmate1, flatmate2);
			Assert.NotEqual(flatmate1.GetHashCode(), flatmate2.GetHashCode());
		}
	}
}
