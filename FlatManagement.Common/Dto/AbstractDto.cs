namespace FlatManagement.Common.Dto
{
	public abstract class AbstractDto : IDto
	{
		public abstract string[] IdFieldNames { get; }
		public abstract string[] FieldNames { get; }
		public abstract string[] AllFieldNames { get; }
	}

	public abstract class AbstractDto<TId> : AbstractDto, IDto<TId>
		where TId : struct
	{
		public AbstractDto() { }

		public abstract TId GetId();
	}
}
