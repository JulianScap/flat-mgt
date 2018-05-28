using System.Collections.Generic;
using FlatManagement.Common.Dal;
using FlatManagement.Common.Dto;
using Microsoft.Extensions.Configuration;

namespace FlatManagement.Common.Bll
{
	public abstract class AbstractReadOnlyService<TDto> : IReadOnlyService<TDto>
		where TDto : IDto, new()
	{
		public IConfiguration Configuration { get; set; }

		protected abstract IReadOnlyDataAccess<TDto> ReadOnlyDal { get; }

		protected AbstractReadOnlyService(IConfiguration configuration)
		{
			this.Configuration = configuration;
		}

		public virtual IEnumerable<TDto> GetAll()
		{
			return ReadOnlyDal.GetAll();
		}

		public virtual TDto GetById(TDto item)
		{
			return ReadOnlyDal.GetById(item);
		}

		public virtual IEnumerable<TDto> GetForUser()
		{
			return ReadOnlyDal.GetForUser();

		}
	}
}
