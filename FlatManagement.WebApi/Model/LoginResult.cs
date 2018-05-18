using FlatManagement.Common.Validation;

namespace FlatManagement.WebApi.Model
{
	public class LoginResult
	{
		public string Token { get; set; }
		public ValidationResult ValidationResult { get; set; }
	}
}
