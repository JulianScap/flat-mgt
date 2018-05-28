using System.Collections.Generic;
using FlatManagement.Common.Dto;
using FlatManagement.Common.Validation;

namespace FlatManagement.Common.Bll
{
	public interface IService<TDto> : IReadOnlyService<TDto>
		where TDto : IDto, new()
	{
		void Delete(IEnumerable<TDto> items);
		void Delete(TDto item);
		ValidationResult Save(IEnumerable<TDto> items);
		ValidationResult Save(TDto item);
	}
}
