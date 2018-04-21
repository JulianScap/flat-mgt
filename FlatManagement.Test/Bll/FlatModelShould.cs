using System.Linq;
using FlatManagement.Bll.Impl;
using FlatManagement.Bll.Interface;
using FlatManagement.Common.Services;
using FlatManagement.Dto.Entities;
using FlatManagement.Test.Tools;
using Xunit;

namespace FlatManagement.Test.Bll
{
	public class FlatModelShould : TestBase
	{
		[Fact]
		public void ReturnAValidModelObject()
		{
			IFlatModel ptm = ServiceLocator.Instance.GetService<IFlatModel>();

			Assert.NotNull(ptm);
			Assert.IsType<FlatModel>(ptm);
		}

		[Theory]
		[InlineData(22)]
		public void BeAbleToGetById(int id)
		{
			IFlatModel ptm = ServiceLocator.Instance.GetService<IFlatModel>();
			ptm.GetById(id);

			Assert.NotEmpty(ptm);
			Assert.Equal(id, ptm.Single().FlatId);
		}

		[Theory]
		[InlineData("Rue Amelot", "90 rue Amelot, Paris 11")]
		public void BeAbleToSaveANewFlat(string name, string address)
		{
			IFlatModel ptm = ServiceLocator.Instance.GetService<IFlatModel>();

			Flat flat = ptm.NewInstance();
			flat.Name = name;
			flat.Address = address;

			ptm.Add(flat);
			ptm.PersistAll();

			Assert.NotEmpty(ptm);
			Assert.NotEqual(0, flat.FlatId);
		}

		[Theory]
		[InlineData("Rue Amelo", "90 rue Amelot, Paris 1", "Rue Amelot fixed", "90 rue Amelot, Paris 11 fixed")]
		public void BeAbleToUpdateAFlat(string name, string address, string otherName, string otherAddress)
		{
			IFlatModel ptm = ServiceLocator.Instance.GetService<IFlatModel>();

			Flat flat = ptm.NewInstance();
			flat.Name = name;
			flat.Address = address;

			ptm.Add(flat);
			ptm.PersistAll();

			flat.Name = otherName;
			flat.Address = otherAddress;
			ptm.PersistAll();

			Assert.NotEmpty(ptm);
		}

		[Theory]
		[InlineData("Rue Amelot", "90 rue Amelot, Paris 11")]
		public void BeAbleToDeleteAFlat(string name, string address)
		{
			IFlatModel ptm = ServiceLocator.Instance.GetService<IFlatModel>();

			Flat flat = ptm.NewInstance();
			flat.Name = name;
			flat.Address = address;

			ptm.Add(flat);
			ptm.PersistAll();
			ptm.DeleteAll();
			Assert.Empty(ptm);

			ptm.GetById(flat.FlatId);
			Assert.Empty(ptm);
		}
	}
}
