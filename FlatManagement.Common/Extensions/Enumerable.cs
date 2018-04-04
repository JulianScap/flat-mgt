﻿using System.Collections.Generic;
using System.Linq;

namespace FlatManagement.Common.Extensions
{
	public static class Enumerable
	{
		public static bool IsEmpty<T>(this IEnumerable<T> that)
		{
			return !that.Any();
		}
	}
}
