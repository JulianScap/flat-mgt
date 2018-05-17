using FlatManagement.Common.Dal;
using FlatManagement.Dal.Interface;
using FlatManagement.Dto.Entities;
using Microsoft.Extensions.Configuration;

namespace FlatManagement.Dal.Impl
{
	internal class FlatmateDataAccess : AbstractDataAccess<Flatmate>, IFlatmateDataAccess
	{
		protected FlatmateDataAccess(IConfiguration configuration) : base(configuration)
		{
		}
	}
}
