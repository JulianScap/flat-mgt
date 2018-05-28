using FlatManagement.Bll.Impl;
using FlatManagement.Bll.Interface;
using FlatManagement.Common.Dal;
using FlatManagement.Dal.Impl;
using FlatManagement.Dto.Entities;
using FlatManagement.Test.Tools;
using Xunit;

namespace FlatManagement.Test.Bll
{
	public class FlatModelShould : TestBase
	{
		private IFlatService GetFlatService()
		{
			var conf = GetConfiguration();
			var uip = new TestUserInfoProvider();
			var dh = new DatacallsHandler(conf, uip);
			var dal = new FlatDataAccess(conf, dh);
			return new FlatService(dal, conf);
		}

		[Theory]
		[InlineData(22)]
		public void BeAbleToGetById(int id)
		{
			IFlatService flatService = GetFlatService();

			Flat flat = flatService.GetById(new Flat() { FlatId = id });

			Assert.NotNull(flat);
			Assert.Equal(id, flat.FlatId);
		}

		[Theory]
		[InlineData("Rue Amelot", "90 rue Amelot, Paris 11")]
		public void BeAbleToSaveANewFlat(string name, string address)
		{
			IFlatService flatService = GetFlatService();

			Flat flat = new Flat()
			{
				Name = name,
				Address = address
			};

			flatService.Save(flat);

			Assert.NotEqual(0, flat.FlatId);
		}

		[Theory]
		[InlineData("Rue Amelo", "90 rue Amelot, Paris 1", "Rue Amelot fixed", "90 rue Amelot, Paris 11 fixed")]
		public void BeAbleToUpdateAFlat(string name, string address, string otherName, string otherAddress)
		{
			IFlatService flatService = GetFlatService();
			Flat flat = new Flat()
			{
				Name = name,
				Address = address
			};

			flatService.Save(flat);

			flat.Name = otherName;
			flat.Address = otherAddress;

			flatService.Save(flat);

			// TODO User identity issue
			//Flat hydratedFlat = flatService.GetById(flat);
			//Assert.Equal(flat, hydratedFlat);
		}

		[Theory]
		[InlineData("Rue Amelot", "90 rue Amelot, Paris 11")]
		public void BeAbleToDeleteAFlat(string name, string address)
		{
			IFlatService flatService = GetFlatService();
			Flat flat = new Flat()
			{
				Name = name,
				Address = address
			};
			flatService.Save(flat);
			flatService.Delete(flat);

			Flat deletedFlat = flatService.GetById(flat);
			Assert.Null(deletedFlat);
		}
	}
}
