using FlatManagement.Common.Dal;
using FlatManagement.Common.Dto;
using FlatManagement.Common.Validation;
using Microsoft.Extensions.Configuration;

namespace FlatManagement.Common.Bll
{
	public abstract class AbstractModel<TDto> : AbstractReadOnlyModel<TDto>, IModel<TDto>
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

		public virtual ValidationResult PersistAll()
		{
			ValidationResult result = Validate();
			IDataAccess<TDto> dal = GetDal();
			if (result.IsValid)
			{
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
			return result;
		}

		public virtual void DeleteAll()
		{
			IDataAccess<TDto> dal = GetDal();

			foreach (TDto item in this)
			{
				dal.Delete(item);
			}

			Clear();
		}

		public virtual ValidationResult Validate()
		{
			ValidationResult result = new ValidationResult();

			foreach (TDto item in items)
			{
				result.Add(item.Validate());
			}

			return result;
		}
	}
}
