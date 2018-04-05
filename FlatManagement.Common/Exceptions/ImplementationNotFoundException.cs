using System;

namespace FlatManagement.Common.Exceptions
{
	[Serializable]
	public class ImplementationNotFoundException : BaseException
	{
		public ImplementationNotFoundException(Type type, string factoryType) : base($"Can't find {factoryType} type: {type.FullName}") { }
		public ImplementationNotFoundException() { }
		public ImplementationNotFoundException(string message) : base(message) { }
		public ImplementationNotFoundException(string message, Exception inner) : base(message, inner) { }
		protected ImplementationNotFoundException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}
}
