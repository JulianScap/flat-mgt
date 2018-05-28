using FlatManagement.Common.Dal;
using FlatManagement.Dal.Interface;
using FlatManagement.Dto.Entities;
using Microsoft.Extensions.Configuration;

namespace FlatManagement.Dal.Impl
{
	public class FlatDataAccess : AbstractDataAccess<Flat>, IFlatDataAccess
	{
		public FlatDataAccess(IConfiguration configuration, IDatacallsHandler handler) : base(configuration, handler)
		{
		}
	}
}
