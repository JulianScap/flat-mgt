using System.Collections.Generic;
using FlatManagement.Common.Dal;
using FlatManagement.Dal.Impl;
using FlatManagement.Dal.Interface;
using FlatManagement.Dto.Entities;
using FlatManagement.Test.Tools;
using Xunit;

namespace FlatManagement.Test.Dal
{
	public class FlatDataAccessShould : TestBase
	{
		private IFlatDataAccess GetPeriodTypeService()
		{
			var conf = GetConfiguration();
			var uip = new TestUserInfoProvider();
			var dh = new DatacallsHandler(conf, uip);
			return new FlatDataAccess(conf, dh);
		}

		[Fact]
		public void ReturnAValidDataAccessObject()
		{
			IFlatDataAccess da = GetPeriodTypeService();

			Assert.NotNull(da);
			Assert.IsType<FlatDataAccess>(da);
		}

		[Fact]
		public void BeAbleToReturnAllTheTableContent()
		{
			IFlatDataAccess da = GetPeriodTypeService();
			IEnumerable<Flat> flats = da.GetAll();

			Assert.NotEmpty(flats);
		}

		[Fact]
		public void BeAbleToReturnASingleFlatById()
		{
			IFlatDataAccess da = GetPeriodTypeService();
			Flat flat = da.GetById(new Flat(22));

			Assert.NotNull(flat);
		}

		[Fact]
		public void BeAbleToUpdateAFlat()
		{
			IFlatDataAccess da = GetPeriodTypeService();
			Flat flat = da.GetById(new Flat(22));

			if (flat.Address == "4E MacAulay Street")
			{
				flat.Address = "19A Mount Eden Road";
			}
			else
			{
				flat.Address = "4E MacAulay Street";
			}

			if (flat.Name == "4E")
			{
				flat.Name = "19A";
			}
			else
			{
				flat.Name = "4E";
			}

			da.Update(flat);

			Flat hydratedFlat = da.GetById(new Flat(22));

			Assert.Equal(flat, hydratedFlat);
		}

		[Fact]
		public void BeAbleToInsertAFlat()
		{
			IFlatDataAccess da = GetPeriodTypeService();

			Flat newFlat = new Flat()
			{
				Address = "123 rue Bidon, 74191 Morzine",
				Name = "Bidon",
			};

			da.Insert(newFlat);

			Assert.NotEqual(0, newFlat.FlatId);
		}

		[Fact]
		public void BeAbleToDeleteAFlat()
		{
			IFlatDataAccess da = GetPeriodTypeService();

			Flat newFlat = new Flat()
			{
				Address = "123 rue Bidon, 74191 Morzine",
				Name = "Bidon",
			};

			da.Insert(newFlat);

			da.Delete(newFlat);

			Flat hydratedFlat = da.GetById(newFlat);

			Assert.Null(hydratedFlat);
		}
	}
}
