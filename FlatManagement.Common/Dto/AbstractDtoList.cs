using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace FlatManagement.Common.Dto
{
	[DebuggerDisplay("Count: {Count}")]
	public abstract class AbstractDtoList<TDto> : IDtoList<TDto>, IReadOnlyCollection<TDto>, IEnumerable<TDto>, IEnumerable
		where TDto : new()
	{
		protected readonly List<TDto> items;

		public AbstractDtoList()
		{
			items = new List<TDto>();
		}

		protected virtual TDto GetNewDto()
		{
			return new TDto();
		}

		#region List<T> delegates
		public virtual int Count { get { return items.Count; } }

		public virtual void Clear()
		{
			items.Clear();
		}

		public virtual void AddRange(IEnumerable<TDto> collection)
		{
			items.AddRange(collection);
		}

		public virtual int RemoveAll(Predicate<TDto> predicate)
		{
			return items.RemoveAll(x => predicate(x));
		}
		#endregion

		#region IEnumerable
		IEnumerator<TDto> IEnumerable<TDto>.GetEnumerator()
		{
			return items.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return items.GetEnumerator();
		}
		#endregion
	}
}
