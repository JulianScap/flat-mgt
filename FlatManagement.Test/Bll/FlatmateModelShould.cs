using System.Collections.Generic;
using FlatManagement.Bll.Impl;
using FlatManagement.Bll.Interface;
using FlatManagement.Common.Dal;
using FlatManagement.Common.Security;
using FlatManagement.Dal.Interface;
using FlatManagement.Dto.Entities;
using FlatManagement.Test.Tools;
using Moq;
using Xunit;

namespace FlatManagement.Test.Bll
{
	public class FlatmateModelShould : TestBase
	{
		private ICryptoHelper GetCryptoHelper()
		{
			var conf = GetConfiguration();
			return new CryptoHelper(conf);
		}

		private IFlatmateService GetFlatmateService()
		{
			var conf = GetConfiguration();
			var uip = new TestUserInfoProvider();
			var dh = new DatacallsHandler(conf, uip);
			var pb = new ParametersBuilder();

			Mock<IFlatmateDataAccess> dal = new Mock<IFlatmateDataAccess>();
			dal.Setup(x => x.SavePassword(It.IsAny<Flatmate>()));
			dal.Setup(x => x.GetForUser()).Returns(new Flatmate[] { new Flatmate(123) });

			var ch = new CryptoHelper(conf);
			return new FlatmateService(dal.Object, conf, ch);
		}

		[Fact]
		public void ReturnAValidAccountByLogin()
		{
			IFlatmateService fs = GetFlatmateService();
			IEnumerable<Flatmate> flatmates = fs.GetForUser();
			Assert.NotEmpty(flatmates);
		}

		[Fact]
		public void ValidatePassword()
		{
			IFlatmateService fs = GetFlatmateService();

			Flatmate flatmate = new Flatmate(123)
			{
				Password = GetCryptoHelper().Encrypt("Julian123")
			};
			fs.PreparePassword(flatmate);
			var password = GetCryptoHelper().Encrypt("Julian123");
			var result = fs.CheckPassword(flatmate, password);

			Assert.True(result.IsValid);
		}
	}
}
