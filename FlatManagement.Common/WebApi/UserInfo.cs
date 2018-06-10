using System.Diagnostics;

namespace FlatManagement.Common.WebApi
{
	[DebuggerDisplay("{Login};{Role}")]
	public class UserInfo
	{
		public string Login { get; set; }
		public string Role { get; set; }
	}
}
