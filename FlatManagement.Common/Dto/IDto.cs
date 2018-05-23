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

		/// <summary>
		/// Data and id fields' type
		/// </summary>
		TypeEnum[] AllFieldTypes { get; }

		/// <summary>
		/// Everything except the id fields' type
		/// </summary>
		TypeEnum[] DataFieldTypes { get; }

		/// <summary>
		/// Only the id fields' type
		/// </summary>
		TypeEnum[] IdFieldTypes { get; }

		bool IsPersisted { get; }

		object GetFieldValue(string fieldName);

		void SetFieldValue(string fieldName, object value);
	}
}
