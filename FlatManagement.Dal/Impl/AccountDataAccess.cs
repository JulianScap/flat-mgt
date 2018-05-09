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
	}
}
