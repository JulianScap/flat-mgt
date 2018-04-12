using System.Collections.Generic;
using System.Linq;
using FlatManagement.Bll.Interface;
using FlatManagement.Common.Dto;
using FlatManagement.Dal.Interface;

namespace FlatManagement.Bll.Impl
{
	internal abstract class AbstractModel<TDto> : AbstractDtoList<TDto>, IModel<TDto>
		where TDto : class, new()
	{
		protected abstract IDataAccess<TDto> GetDal(params object[] args);

		public AbstractModel()
		{
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
