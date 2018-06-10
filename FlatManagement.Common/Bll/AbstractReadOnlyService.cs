using System.Collections.Generic;
using FlatManagement.Common.Dal;
using FlatManagement.Common.Dto;
using Microsoft.Extensions.Configuration;

namespace FlatManagement.Common.Bll
{
	public abstract class AbstractReadOnlyService<TDto> : IReadOnlyService<TDto>
		where TDto : IDto, new()
	{
		protected readonly IConfiguration configuration;

		protected readonly IReadOnlyDataAccess<TDto> readOnlyDal;

		protected AbstractReadOnlyService(IReadOnlyDataAccess<TDto> readOnlyDal, IConfiguration configuration)
		{
			this.configuration = configuration;
			this.readOnlyDal = readOnlyDal;
		}

		public virtual IEnumerable<TDto> GetAll()
		{
			return readOnlyDal.GetAll();
		}

		public virtual TDto GetById(TDto item)
		{
			return readOnlyDal.GetById(item);
		}

		public virtual IEnumerable<TDto> GetForUser()
		{
			return readOnlyDal.GetForUser();
		}
	}
}
