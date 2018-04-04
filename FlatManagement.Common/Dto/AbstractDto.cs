namespace FlatManagement.Common.Dto
{
	public abstract class AbstractDto : IDto
	{
	}

	public abstract class AbstractDto<TId> : AbstractDto, IDto<TId>
		where TId : struct
	{
		public AbstractDto() { }

		public abstract TId GetId();
	}
}
