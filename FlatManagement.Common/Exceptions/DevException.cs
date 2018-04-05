using System;

namespace FlatManagement.Common.Exceptions
{
	[Serializable]
	public class DevException : BaseException
	{
		public DevException() { }
		public DevException(string message) : base(message) { }
		public DevException(string message, Exception inner) : base(message, inner) { }
		protected DevException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}
}
