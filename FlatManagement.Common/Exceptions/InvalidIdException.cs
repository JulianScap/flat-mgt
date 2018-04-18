using System;

namespace FlatManagement.Common.Exceptions
{
	[Serializable]
	public class InvalidIdException : BaseException
	{
		public InvalidIdException() { }
		public InvalidIdException(string message) : base(message) { }
		public InvalidIdException(string message, Exception inner) : base(message, inner) { }
		protected InvalidIdException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}
}
