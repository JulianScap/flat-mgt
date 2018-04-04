namespace FlatManagement.Dal.Interface
{
	public interface IDataAccess
	{

	}

	public interface IDataAccess<TList> : IDataAccess
	{
		TList GetAll();
	}
}
