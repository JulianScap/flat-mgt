using FlatManagement.Bll.Interface;
using FlatManagement.Common.Dto;
using FlatManagement.Dal.Interface;

namespace FlatManagement.Bll.Impl
{
	internal abstract class AbstractModel<TList, TDto> : AbstractDtoList<TDto>, IModel<TList>
		where TList : IDtoList, new()
		where TDto : new()
	{
		protected TList Items { get; set; }

		protected abstract IDataAccess<TList> GetDal(params object[] args);

		public void GetAll()
		{
			Items = GetDal().GetAll();
		}
	}
}
