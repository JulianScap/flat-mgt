using System;
using System.Collections;
using System.Collections.Generic;

namespace FlatManagement.Common.Dto
{
	public interface IDtoList<TDto> : ICollection<TDto>, IEnumerable<TDto>, IEnumerable, IList<TDto>, IReadOnlyCollection<TDto>, IReadOnlyList<TDto>, ICollection, IList
		where TDto : IDto, new()
	{
		void AddRange(IEnumerable<TDto> collection);
		int RemoveAll(Predicate<TDto> predicate);
		new int Count { get; }
		new TDto this[int index] { get; set; }
	}
}
