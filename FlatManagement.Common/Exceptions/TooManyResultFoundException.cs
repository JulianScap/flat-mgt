using System;

namespace FlatManagement.Common.Exceptions
{
	[Serializable]
	public class TooManyResultFoundException : BaseException
	{
		public TooManyResultFoundException() { }
		public TooManyResultFoundException(string message) : base(message) { }
		public TooManyResultFoundException(string message, Exception inner) : base(message, inner) { }
		protected TooManyResultFoundException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}
}
