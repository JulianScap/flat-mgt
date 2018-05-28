using System.Collections.Generic;
using FlatManagement.Bll.Impl;
using FlatManagement.Bll.Interface;
using FlatManagement.Common.Dal;
using FlatManagement.Common.Security;
using FlatManagement.Dal.Impl;
using FlatManagement.Dto.Entities;
using FlatManagement.Test.Tools;
using Xunit;

namespace FlatManagement.Test.Bll
{
	public class FlatmateModelShould : TestBase
	{
		private IFlatmateService GetFlatmateService()
		{
			var conf = GetConfiguration();
			var uip = new TestUserInfoProvider();
			var dh = new DatacallsHandler(conf, uip);
			var pb = new ParametersBuilder();
			var dal = new FlatmateDataAccess(conf, dh, pb);
			var ch = new CryptoHelper(conf);
			return new FlatmateService(dal, conf, ch);
		}

		[Fact]
		public void ReturnAValidAccountByLogin()
		{
			IFlatmateService fs = GetFlatmateService();
			IEnumerable<Flatmate> flatmates = fs.GetForUser();
			Assert.NotEmpty(flatmates);
		}
	}
}
