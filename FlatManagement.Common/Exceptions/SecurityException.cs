using System;

namespace FlatManagement.Common.Exceptions
{
	[Serializable]
	public class SecurityException : BaseException
	{
		public SecurityException() { }
		public SecurityException(string message) : base(message) { }
		public SecurityException(string message, Exception inner) : base(message, inner) { }
		protected SecurityException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}
}
