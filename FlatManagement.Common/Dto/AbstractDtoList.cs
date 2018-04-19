using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace FlatManagement.Common.Dto
{
	[DebuggerDisplay("Count: {Count}")]
	public abstract class AbstractDtoList<TDto> : IDtoList<TDto>, ICollection<TDto>, IEnumerable<TDto>, IEnumerable, IList<TDto>, IReadOnlyCollection<TDto>, IReadOnlyList<TDto>, ICollection, IList
		where TDto : IDto, new()
	{
		protected readonly List<TDto> items;

		public AbstractDtoList()
		{
			items = new List<TDto>();
		}

		#region List<T> delegates
		public virtual int Count
		{
			get { return items.Count; }
		}

		public TDto this[int index]
		{
			get { return items[index]; }
			set { items[index] = value; }
		}

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

		public int IndexOf(TDto item)
		{
			return items.IndexOf(item);
		}

		public void Insert(int index, TDto item)
		{
			items.Insert(index, item);
		}

		public void RemoveAt(int index)
		{
			items.RemoveAt(index);
		}

		public void Add(TDto item)
		{
			items.Add(item);
		}

		public bool Contains(TDto item)
		{
			return items.Contains(item);
		}

		public void CopyTo(TDto[] array, int arrayIndex)
		{
			items.CopyTo(array, arrayIndex);
		}

		public bool Remove(TDto item)
		{
			return items.Remove(item);
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

		#region ICollection implementation
		void ICollection.CopyTo(Array array, int index)
		{
			TDto[] dtoArray = null;

			try
			{
				dtoArray = array.Cast<TDto>().ToArray();
			}
			catch (InvalidCastException ice)
			{
				throw new ArgumentException("Unable to cast the array to TDto", "array", ice);
			}

			items.CopyTo(dtoArray, index);
		}

		bool ICollection.IsSynchronized
		{
			get => ((ICollection)items).IsSynchronized;
		}

		object ICollection.SyncRoot
		{
			get => ((ICollection)items).SyncRoot;
		}

		bool ICollection<TDto>.IsReadOnly
		{
			get => ((ICollection<TDto>)items).IsReadOnly;
		}
		#endregion

		#region IList implementation
		int IList.Add(object value)
		{
			if (value is TDto valueAsTDto)
			{
				items.Add(valueAsTDto);
				return items.Count - 1;
			}
			else
			{
				return -1;
			}
		}

		bool IList.Contains(object value)
		{
			bool result = false;

			if (value is TDto valueAsTDto)
			{
				result = items.Contains(valueAsTDto);
			}

			return result;
		}

		int IList.IndexOf(object value)
		{
			int result = -1;
			if (value is TDto valueAsTDto)
			{
				result = items.IndexOf(valueAsTDto);
			}
			return result;
		}

		void IList.Insert(int index, object value)
		{
			if (value is TDto valueAsTDto)
			{
				items.Insert(index, valueAsTDto);
			}
		}

		void IList.Remove(object value)
		{
			if (value is TDto valueAsTDto)
			{
				items.Remove(valueAsTDto);
			}
		}

		bool IList.IsFixedSize
		{
			get => ((IList)items).IsFixedSize;
		}

		bool IList.IsReadOnly
		{
			get => ((IList)items).IsReadOnly;
		}

		object IList.this[int index]
		{
			get { return items[index]; }
			set
			{
				if (value is TDto valueAsTDto)
				{
					items[index] = valueAsTDto;
				}
			}
		}
		#endregion
	}
}
