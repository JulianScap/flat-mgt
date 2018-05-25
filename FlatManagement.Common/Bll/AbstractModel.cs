using System;
using FlatManagement.Common.Dal;
using FlatManagement.Common.Dto;
using FlatManagement.Common.Validation;
using Microsoft.Extensions.Configuration;

namespace FlatManagement.Common.Bll
{
	public abstract class AbstractModel<TDto> : AbstractReadOnlyModel<TDto>, IModel<TDto>
		where TDto : IDto, new()
	{
		public ValidationResult ValidationResult { get { return AggregateValidationResult(); } }

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
			Validate();
			IDataAccess<TDto> dal = GetDal();
			if (this.ValidationResult.IsValid)
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

		public virtual void Validate()
		{
			foreach (TDto item in items)
			{
				item.Validate();
				Validate(item);
			}
		}

		protected virtual ValidationResult AggregateValidationResult()
		{
			ValidationResult result = new ValidationResult();

			foreach (TDto item in this.items)
			{
				result.Add(item.ValidationResult);
			}

			return result;
		}

		protected virtual void Validate(TDto item)
		{
		}
	}
}
