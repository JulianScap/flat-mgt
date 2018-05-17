using System;
using System.Collections.Generic;
using System.Linq;

namespace FlatManagement.Common.Extensions
{
	public static class EnumerableExtentions
	{
		public static bool IsEmpty<T>(this IEnumerable<T> that)
		{
			if (that == null)
			{
				throw new ArgumentNullException("that");
			}

			return !that.Any();
		}

		public static IEnumerable<T> MergeWith<T>(this IEnumerable<T> that, params IEnumerable<T>[] collections)
		{
			if (that == null)
			{
				throw new ArgumentNullException("that");
			}

			List<T> result = new List<T>(that);

			foreach (IEnumerable<T> collection in collections)
			{
				if (collection != null)
				{
					result.AddRange(collection);
				}
			}

			return result;
		}
	}
}
