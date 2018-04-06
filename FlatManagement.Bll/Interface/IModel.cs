using FlatManagement.Common.Dto;

namespace FlatManagement.Bll.Interface
{
	public interface IModel
	{
		void GetAll();
	}

	public interface IModel<TList> : IModel
		where TList : IDtoList, new()
	{
	}
}
