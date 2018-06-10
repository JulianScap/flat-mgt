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
		protected readonly IDataAccess<TDto> dal;
		protected AbstractService(IDataAccess<TDto> dal, IConfiguration configuration) : base(dal, configuration)
		{
			this.dal = dal;
		}

		public void Delete(TDto item)
		{
			dal.Delete(item);
		}

		public void Delete(IEnumerable<TDto> items)
		{
			foreach (TDto item in items)
			{
				dal.Delete(item);
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
					dal.Update(item);
				}
				else
				{
					dal.Insert(item);
				}
			}
			return result;
		}
	}
}
