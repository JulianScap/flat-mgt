namespace FlatManagement.WebApi.Model
{
	public class LoginRequest
	{
		public string Login { get; set; }
		public string PasswordHash { get; set; }
	}
}
