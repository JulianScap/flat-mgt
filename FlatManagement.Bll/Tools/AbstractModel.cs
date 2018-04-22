using FlatManagement.Common.Dto;
using FlatManagement.Dal.Tools;
using Microsoft.Extensions.Configuration;

namespace FlatManagement.Bll.Tools
{
	internal abstract class AbstractModel<TDto> : AbstractReadOnlyModel<TDto>, IModel<TDto>
		where TDto : IDto, new()
	{
		protected AbstractModel()
		{
		}

		protected AbstractModel(IConfiguration configuration) : base(configuration)
		{
		}

		protected abstract IDataAccess<TDto> GetDal();

		protected override IReadOnlyDataAccess<TDto> GetReadOnlyDal()
		{
			return GetDal();
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

		public void DeleteAll()
		{
			IDataAccess<TDto> dal = GetDal();

			foreach (TDto item in this)
			{
				dal.Delete(item);
			}

			Clear();
		}
	}
}
