namespace FlatManagement.Common.Dto
{
	public interface IDto
	{
		/// <summary>
		/// Only the id fields
		/// </summary>
		string[] IdFieldNames { get; }
		/// <summary>
		/// Everything except the id fields
		/// </summary>
		string[] DataFieldNames { get; }
		/// <summary>
		/// Data and id fields
		/// </summary>
		string[] AllFieldNames { get; }

		TypeEnum[] IdFieldTypes { get; }

		object GetFieldValue(string fieldName);

		void SetFieldValue(string fieldName, object value);
	}

	public interface IDto<TId> : IDto
		where TId : struct
	{
		TId GetId();
	}
}
