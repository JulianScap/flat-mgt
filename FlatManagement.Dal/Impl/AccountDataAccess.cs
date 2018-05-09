using FlatManagement.Common.Dal;
using FlatManagement.Dal.Interface;
using FlatManagement.Dto.Entities;
using Microsoft.Extensions.Configuration;

namespace FlatManagement.Dal.Impl
{
	internal class AccountDataAccess : AbstractDataAccess<Account>, IAccountDataAccess
	{
		protected AccountDataAccess(IConfiguration configuration) : base(configuration)
		{
		}

		public Account GetByLogin(string login)
		{
			DatacallsHandler handler = new DatacallsHandler(configuration);
			string command = GetStoredProcedureName(OperationEnum.Custom, "GetByLogin");
			Parameter[] parameters = new Parameter[1] {
				new Parameter("Login", login)
			};
			object result = handler.GetOne(command, parameters, converter, true);
			return (Account)result;
		}
	}
}
