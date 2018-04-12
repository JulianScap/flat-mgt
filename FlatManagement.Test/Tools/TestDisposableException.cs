using System;

namespace FlatManagement.Test.Tools
{
	[Serializable]
	public class TestDisposableException : Exception
	{
		public TestDisposableException() { }
		public TestDisposableException(string message) : base(message) { }
		public TestDisposableException(string message, Exception inner) : base(message, inner) { }
		protected TestDisposableException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}
}
