using System.Collections;
using System.Collections.Generic;
using FlatManagement.Common.Dto;
using Microsoft.Extensions.Configuration;

namespace FlatManagement.Common.Bll
{
	public interface IReadOnlyModel
	{
		IConfiguration Configuration { set; }
		void GetAll();
		void GetForUser();
	}

	public interface IReadOnlyModel<TDto> : IDtoList<TDto>, IReadOnlyModel, ICollection<TDto>, IEnumerable<TDto>, IEnumerable, IList<TDto>, IReadOnlyCollection<TDto>, IReadOnlyList<TDto>, ICollection, IList
		where TDto : IDto, new()
	{
		TDto NewInstance();
		void GetById(TDto item);
	}
}
