using System.Collections.Generic;
using FlatManagement.Common.Extensions;

namespace FlatManagement.Common.Validation
{
	public class ValidationResult
	{
		public ValidationResult(params string[] messages)
		{
			Messages = new List<string>(messages);
		}

		/// <summary>
		/// The error messages.
		/// </summary>
		public List<string> Messages { get; private set; }

		/// <summary>
		/// Returns true if the Messages collection is empty.
		/// </summary>
		public bool IsValid { get => Messages.IsEmpty(); }
	}
}
