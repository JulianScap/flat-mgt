using System;

namespace FlatManagement.Common.Exceptions
{

	[Serializable]
	public class DisabledOperationException : BaseException
	{
		public DisabledOperationException() { }
		public DisabledOperationException(string message) : base(message) { }
		public DisabledOperationException(string message, Exception inner) : base(message, inner) { }
		protected DisabledOperationException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}
}
