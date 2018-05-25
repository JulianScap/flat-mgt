namespace FlatManagement.Common.Validation
{
	public interface IValidable
	{
		ValidationResult ValidationResult { get; }
		void Validate();
	}
}
