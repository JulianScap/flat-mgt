using System.Diagnostics;

namespace FlatManagement.WebApi.Model
{
	[DebuggerDisplay("{AccountId};{Login};{Role}")]
	public class UserInfo
	{
		public string Login { get; set; }
		public int AccountId { get; internal set; }
		public string Role { get; internal set; }
	}
}
