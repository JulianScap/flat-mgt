﻿using System.Collections;
using System.Collections.Generic;

namespace FlatManagement.Common.Dto
{
	public interface IDtoList
	{
		void Start();
		bool Next();
		void New();
	}

	public interface IDtoList<TDto> : IDtoList, IReadOnlyCollection<TDto>, IEnumerable<TDto>, IEnumerable
	{
	}
}
