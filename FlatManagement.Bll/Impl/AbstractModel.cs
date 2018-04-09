using System.Collections.Generic;
using System.Linq;
using FlatManagement.Bll.Interface;
using FlatManagement.Common.Dto;
using FlatManagement.Dal.Interface;

namespace FlatManagement.Bll.Impl
{
	internal abstract class AbstractModel<TList, TDto> : AbstractDtoList<TDto>, IModel<TList, TDto>
		where TList : IDtoList<TDto>, new()
		where TDto : new()
	{
		protected abstract IDataAccess<TDto> GetDal(params object[] args);

		public AbstractModel()
		{
			base.Clear();
		}

		public void GetAll()
		{
			IDataAccess<TDto> dal = GetDal();
			IEnumerable<TDto> allItems = dal.GetAll();

			base.Clear();
			base.AddRange(allItems.ToList());
		}
	}
}
