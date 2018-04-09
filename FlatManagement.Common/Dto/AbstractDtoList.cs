using System.Collections;
using System.Collections.Generic;

namespace FlatManagement.Common.Dto
{
	public abstract class AbstractDtoList<TDto> : IDtoList<TDto>, IReadOnlyCollection<TDto>, IEnumerable<TDto>, IEnumerable
		where TDto : new()
	{
		private readonly List<TDto> items;
		protected int index;

		public AbstractDtoList()
		{
			index = 0;
			items = new List<TDto>();
		}

		public virtual void Start()
		{
			index = 0;
		}

		public virtual bool Next()
		{
			index += 1;
			if (index < items.Count)
			{
				return true;
			}
			else
			{
				index -= 1;
				return false;
			}
		}

		public virtual void New()
		{
			items.Add(GetNewDto());
			index = items.Count - 1;
		}

		protected virtual TDto GetNewDto()
		{
			return new TDto();
		}

		public virtual TDto Current
		{
			get { return items[index]; }
		}

		public void Insert(TDto item)
		{
			items.Insert(index, item);
		}

		public void Remove()
		{
			items.RemoveAt(index);
			if (index >= items.Count)
			{
				index = items.Count - 1;
			}
		}

		#region List<T> delegates
		public int Count { get { return items.Count; } }

		public void Clear()
		{
			items.Clear();
		}

		public void AddRange(IEnumerable<TDto> collection)
		{
			items.AddRange(collection);
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
