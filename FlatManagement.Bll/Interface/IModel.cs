namespace FlatManagement.Bll.Interface
{
	public interface IModel
	{
		void GetAll();
	}

	public interface IModel<TDto> : IModel
	{
	}
}
