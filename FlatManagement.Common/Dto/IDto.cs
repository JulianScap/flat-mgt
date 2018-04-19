namespace FlatManagement.Common.Dto
{
	public interface IDto
	{
		string[] IdFieldNames { get; }
		string[] FieldNames { get; }
		string[] AllFieldNames { get; }
	}

	public interface IDto<TId> : IDto
		where TId : struct
	{
		TId GetId();
	}
}
