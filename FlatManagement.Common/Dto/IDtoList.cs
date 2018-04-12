using System;
using System.Collections;
using System.Collections.Generic;

namespace FlatManagement.Common.Dto
{
	public interface IDtoList
	{
	}

	public interface IDtoList<TDto> : IDtoList, IReadOnlyCollection<TDto>, IEnumerable<TDto>, IEnumerable
	{
		int RemoveAll(Predicate<TDto> predicate);
	}
}
