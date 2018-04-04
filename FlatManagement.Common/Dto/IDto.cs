namespace FlatManagement.Common.Dto
{
	public interface IDto
	{
	}

	public interface IDto<TId> : IDto
		where TId : struct
	{
		TId GetId();
	}
}
