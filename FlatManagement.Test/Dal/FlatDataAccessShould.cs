using System.Collections.Generic;
using FlatManagement.Common.Services;
using FlatManagement.Dal.Impl;
using FlatManagement.Dal.Interface;
using FlatManagement.Dto.Entities;
using FlatManagement.Test.Tools;
using Xunit;

namespace FlatManagement.Test.Dal
{
	public class FlatDataAccessShould : TestBase
	{
		[Fact]
		public void ReturnAValidDataAccessObject()
		{
			IFlatDataAccess da = ServiceLocator.Instance.GetService<IFlatDataAccess>();

			Assert.NotNull(da);
			Assert.IsType<FlatDataAccess>(da);
		}

		[Fact]
		public void BeAbleToReturnAllTheTableContent()
		{
			IFlatDataAccess da = ServiceLocator.Instance.GetService<IFlatDataAccess>();
			IEnumerable<Flat> flats = da.GetAll();

			Assert.NotEmpty(flats);
		}

		[Fact]
		public void BeAbleToReturnASingleFlatById()
		{
			IFlatDataAccess da = ServiceLocator.Instance.GetService<IFlatDataAccess>();
			Flat flat = da.GetById(22);

			Assert.NotNull(flat);
		}

		[Fact]
		public void BeAbleToUpdateAFlat()
		{
			IFlatDataAccess da = ServiceLocator.Instance.GetService<IFlatDataAccess>();
			Flat flat = da.GetById(22);

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

			Flat hydratedFlat = da.GetById(22);

			Assert.Equal(flat, hydratedFlat);
		}

		[Fact]
		public void BeAbleToInsertAFlat()
		{
			IFlatDataAccess da = ServiceLocator.Instance.GetService<IFlatDataAccess>();

			Flat newFlat = new Flat()
			{
				Address = "123 rue Bidon, 74191 Morzine",
				Name = "Bidon", 
			};

			da.Insert(newFlat);

			Assert.NotEqual(0, newFlat.FlatId);
		}
	}
}
