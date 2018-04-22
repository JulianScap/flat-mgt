namespace FlatManagement.Bll.Tools
{
	public interface IModel : IReadOnlyModel
	{
		void DeleteAll();
		void PersistAll();
	}

	public interface IModel<TDto> : IReadOnlyModel<TDto>, IModel
	{
	}
}
