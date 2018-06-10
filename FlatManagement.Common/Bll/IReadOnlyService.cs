using System.Collections.Generic;
using FlatManagement.Common.Dto;
using Microsoft.Extensions.Configuration;

namespace FlatManagement.Common.Bll
{
	public interface IReadOnlyService<TDto>
		where TDto : IDto, new()
	{
		TDto GetById(TDto item);
		IEnumerable<TDto> GetAll();
		IEnumerable<TDto> GetForUser();
	}
}
