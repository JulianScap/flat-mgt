using FlatManagement.Bll.Interface;
using FlatManagement.Test.Tools;
using FlatManagement.WebApi.Controllers;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace FlatManagement.Test.WebApi
{
	public class FlatmateControlerShould : TestBase
	{
		//[Theory]
		//[InlineData("Juju", "19A")]
		//public void ReturnValidFlatmateInAFlat(string nickname, string flatName)
		//{
		//	IConfiguration configuration = GetConfiguration();
		//	FlatmateController fc = new FlatmateController(configuration);
		//	IFlatmateModel ifm = fc.Get(nickname, flatName);

		//	Assert.NotNull(ifm);
		//	Assert.NotEmpty(ifm);
		//	Assert.Equal(nickname, ifm[0].Nickname);
		//}

		//[Theory]
		//[InlineData("Juju", "19A")]
		//public void ReturnValidFlatmateInAnExistingFlat(string nickname, string flatName)
		//{
		//	IConfiguration configuration = GetConfiguration();
		//	FlatmateController fmc = new FlatmateController(configuration);
		//	IFlatmateModel ifmm = fmc.Get(nickname, flatName);

		//	FlatController fc = new FlatController(configuration);
		//	IFlatModel ifm = fc.Get(ifmm[0].FlatId);

		//	Assert.NotNull(ifm);
		//	Assert.NotEmpty(ifm);
		//	Assert.Equal(flatName, ifm[0].Name);
		//}
	}
}
