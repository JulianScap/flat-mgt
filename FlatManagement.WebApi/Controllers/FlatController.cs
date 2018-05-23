using System.Transactions;
using FlatManagement.Bll.Interface;
using FlatManagement.Common.Bll;
using FlatManagement.Common.Services;
using FlatManagement.Common.Transaction;
using FlatManagement.Dto.Entities;
using FlatManagement.WebApi.Controllers.Base;
using FlatManagement.WebApi.Model;
using FlatManagement.WebApi.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace FlatManagement.WebApi.Controllers
{
	[TokenAuthorize]
	public class FlatController : ApiBaseController<IFlatModel, Flat>
	{
		public FlatController(IConfiguration configuration)
			: base(configuration)
		{
		}

		[HttpGet("{id}")]
		public virtual IFlatModel Get(int id)
		{
			return GetByDto(new Flat(id));
		}

		public override IFlatModel Get()
		{
			IFlatModel model = ServiceLocator.Instance.GetService<IFlatModel>();

			UserInfo userInfo = base.GetUserInfo();

			model.GetByLogin(userInfo.Login);

			return model;
		}

		public override IFlatModel PersistAll()
		{
			string content = base.GetBodyAsString();
			SaveFlatRequest sfr = JsonConvert.DeserializeObject<SaveFlatRequest>(content);

			IFlatmateModel flatmates = ModelSerialiser.Instance.Deserialize<IFlatmateModel>(sfr.FlatmatesJson);
			IFlatModel flats = ModelSerialiser.Instance.Deserialize<IFlatModel>(sfr.FlatsJson);

			using (TransactionScope scope = TransactionUtil.New())
			{
				flats.PersistAll();
				foreach (Flatmate flatmate in flatmates)
				{
					flatmate.FlatId = flats[0].FlatId;
				}
				flatmates.PersistAll();
				scope.Complete();
			}

			return flats;
		}
	}
}
