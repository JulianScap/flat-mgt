using System.Linq;
using FlatManagement.Bll.Impl;
using FlatManagement.Bll.Interface;
using FlatManagement.Common.Services;
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
	}
}
