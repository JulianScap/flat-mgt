using System.Collections.Generic;
using FlatManagement.Dal;
using FlatManagement.Dal.Impl;
using FlatManagement.Dal.Interface;
using FlatManagement.Dto.Entities;
using Xunit;

namespace FlatManagement.Test.Dal
{
	public class FlatDataAccessShould
	{
		[Fact]
		public void ReturnAValidDataAccessObject()
		{
			IFlatDataAccess da = DalFactory.Instance.Get<IFlatDataAccess>();

			Assert.NotNull(da);
			Assert.IsType<FlatDataAccess>(da);
		}

		[Fact]
		public void BeAbleToReturnAllTheTableContent()
		{
			IFlatDataAccess da = DalFactory.Instance.Get<IFlatDataAccess>();
			IEnumerable<Flat> flats = da.GetAll();

			Assert.NotEmpty(flats);
		}

		[Fact]
		public void BeAbleToReturnASingleFlatById()
		{
			IFlatDataAccess da = DalFactory.Instance.Get<IFlatDataAccess>();
			Flat flat = da.GetById(22);

			Assert.NotNull(flat);
		}

		[Fact]
		public void BeAbleToUpdateAFlat()
		{
			IFlatDataAccess da = DalFactory.Instance.Get<IFlatDataAccess>();
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
	}
}
