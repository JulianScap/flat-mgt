using System.Collections.Generic;
using FlatManagement.Common.Dal;
using FlatManagement.Common.Dto;
using FlatManagement.Common.Validation;
using Microsoft.Extensions.Configuration;

namespace FlatManagement.Common.Bll
{
	public abstract class AbstractService<TDto> : AbstractReadOnlyService<TDto>, IService<TDto>
		where TDto : IDto, new()
	{
		protected AbstractService(IConfiguration configuration) : base(configuration)
		{
		}

		protected abstract IDataAccess<TDto> Dal { get; }
		protected override IReadOnlyDataAccess<TDto> ReadOnlyDal => Dal;

		public virtual void PersistAll()
		{
		}

		public void Delete(TDto item)
		{
			Dal.Delete(item);
		}

		public void Delete(IEnumerable<TDto> items)
		{
			foreach (TDto item in items)
			{
				Dal.Delete(item);
			}
		}

		public ValidationResult Save(IEnumerable<TDto> items)
		{
			ValidationResult result = new ValidationResult();

			foreach (TDto item in items)
			{
				result.Add(Save(item));
			}

			return result;
		}

		public ValidationResult Save(TDto item)
		{
			ValidationResult result = item.Validate();
			if (result.IsValid)
			{
				if (item.IsPersisted)
				{
					Dal.Update(item);
				}
				else
				{
					Dal.Insert(item);
				}
			}
			return result;
		}
	}
}
