using System.Collections.Generic;
using FlatManagement.Common.Extensions;

namespace FlatManagement.Common.Validation
{
	public class ValidateResult
	{
		public IEnumerable<string> Reason { get; set; }
		public bool IsValid { get => Reason.IsEmpty(); }
	}
}
