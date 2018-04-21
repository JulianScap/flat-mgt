using System.Collections.Generic;
using System.Linq;
using FlatManagement.Bll.Interface;
using FlatManagement.Common.Dto;
using FlatManagement.Dal.Interface;
using Microsoft.Extensions.Configuration;

namespace FlatManagement.Bll.Impl
{
	internal abstract class AbstractModel<TDto> : AbstractDtoList<TDto>, IModel<TDto>
		where TDto : IDto, new()
	{
		public IConfiguration Configuration { get; set; }

		protected AbstractModel()
		{

		}

		protected AbstractModel(IConfiguration configuration)
		{
			this.Configuration = configuration;
		}

		protected abstract IDataAccess<TDto> GetDal();

		public virtual void GetAll()
		{
			IDataAccess<TDto> dal = GetDal();
			IEnumerable<TDto> allItems = dal.GetAll();

			base.Clear();
			base.AddRange(allItems.ToList());
		}

		public virtual void PersistAll()
		{
			IDataAccess<TDto> dal = GetDal();

			foreach (TDto item in this)
			{
				if (item.IsPersisted)
				{
					dal.Update(item);
				}
				else
				{
					dal.Insert(item);
				}
			}
		}

		public virtual void GetById(params object[] ids)
		{
			IDataAccess<TDto> dal = GetDal();
			TDto item = dal.GetById(ids);
			base.Clear();
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
