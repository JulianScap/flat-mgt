namespace FlatManagement.Common.Validation
{
	public interface IValidable
	{
		ValidationResult ValidationResult { get; }
		ValidationResult Validate();
	}
}
