using System.Collections.Generic;
using System.Linq;
using FlatManagement.Common.Dto;
using FlatManagement.Dal.Tools;
using Microsoft.Extensions.Configuration;

namespace FlatManagement.Bll.Tools
{
	public abstract class AbstractReadOnlyModel<TDto> : AbstractDtoList<TDto>, IReadOnlyModel<TDto>
		where TDto : IDto, new()
	{
		public IConfiguration Configuration { get; set; }

		protected abstract IReadOnlyDataAccess<TDto> GetReadOnlyDal();

		protected AbstractReadOnlyModel()
		{

		}

		protected AbstractReadOnlyModel(IConfiguration configuration)
		{
			this.Configuration = configuration;
		}

		public virtual void GetAll()
		{
			IReadOnlyDataAccess<TDto> dal = GetReadOnlyDal();
			IEnumerable<TDto> allItems = dal.GetAll();

			Clear();
			AddRange(allItems.ToList());
		}

		public virtual void GetById(params object[] ids)
		{
			IReadOnlyDataAccess<TDto> dal = GetReadOnlyDal();
			TDto item = dal.GetById(ids);
			Clear();
			if (item != null)
			{
				base.Add(item);
			}
		}

		public virtual TDto NewInstance()
		{
			return new TDto();
		}
	}
}
