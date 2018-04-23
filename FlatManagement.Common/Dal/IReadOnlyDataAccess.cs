using System.Collections.Generic;
using FlatManagement.Common.Dto;

namespace FlatManagement.Common.Dal
{
	public interface IReadOnlyDataAccess { }

	public interface IReadOnlyDataAccess<TDto> : IReadOnlyDataAccess
		where TDto : IDto, new()
	{
		IEnumerable<TDto> GetAll();
		TDto GetById(TDto item);
	}
}
