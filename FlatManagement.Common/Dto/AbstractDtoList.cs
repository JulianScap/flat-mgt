using System.Collections;
using System.Collections.Generic;

namespace FlatManagement.Common.Dto
{
	public abstract class AbstractDtoList : IDtoList
	{
		public abstract void Start();
		public abstract bool Next();
		public abstract void New();
	}

	public abstract class AbstractDtoList<TDto> : AbstractDtoList, IDtoList<TDto>, IReadOnlyCollection<TDto>, IEnumerable<TDto>, IEnumerable
		where TDto : new()
	{
		private List<TDto> items;
		protected int index;

		public AbstractDtoList()
		{
			index = 0;
			items = new List<TDto>();
		}

		public override void Start()
		{
			index = 0;
		}

		public override bool Next()
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

		public override void New()
		{
			items.Add(GetNewDto());
			index = items.Count - 1;
		}

		protected virtual TDto GetNewDto()
		{
			return new TDto();
		}

		protected virtual TDto Current
		{
			get { return items[index]; }
		}

		public int Count { get { return items.Count; } }

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
