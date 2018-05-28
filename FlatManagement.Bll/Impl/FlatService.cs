using FlatManagement.Bll.Interface;
using FlatManagement.Common.Bll;
using FlatManagement.Dal.Interface;
using FlatManagement.Dto.Entities;
using Microsoft.Extensions.Configuration;

namespace FlatManagement.Bll.Impl
{
	public class FlatService : AbstractService<Flat>, IFlatService
	{
		private readonly IFlatDataAccess flatDataAccess;

		public FlatService(IFlatDataAccess flatDataAccess, IConfiguration configuration) : base(flatDataAccess, configuration)
		{
			this.flatDataAccess = flatDataAccess;
		}
	}
}
