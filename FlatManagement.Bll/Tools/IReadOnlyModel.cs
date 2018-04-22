using System.Collections;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace FlatManagement.Bll.Tools
{
	public interface IReadOnlyModel
	{
		IConfiguration Configuration { set; }
		void GetAll();
	}

	public interface IReadOnlyModel<TDto> : IReadOnlyModel, ICollection<TDto>, IEnumerable<TDto>, IEnumerable, IList<TDto>, IReadOnlyCollection<TDto>, IReadOnlyList<TDto>, ICollection, IList
	{
		TDto NewInstance();
		void GetById(TDto item);
	}
}
