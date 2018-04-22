using FlatManagement.Dal.Tools;
using FlatManagement.Dal.Interface;
using FlatManagement.Dto.Entities;
using Microsoft.Extensions.Configuration;

namespace FlatManagement.Dal.Impl
{
	internal class FlatDataAccess : AbstractDataAccess<Flat>, IFlatDataAccess
	{
		protected FlatDataAccess(IConfiguration configuration) : base(configuration)
		{
		}

		public Flat GetById(int flatId)
		{
			return GetById(new Flat() { FlatId = flatId });
		}
	}
}
