namespace FlatManagement.Bll.Interface
{
	public interface IModel { }

	public interface IModel<TDto> : IModel
	{
		void GetAll();
	}
}
