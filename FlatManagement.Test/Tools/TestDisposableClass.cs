using System;

namespace FlatManagement.Test.Tools
{
	public class ThrowOnDispose<TException> : IDisposable
		where TException : Exception, new()
	{
		public void Dispose()
		{
			throw new TException();
		}
	}
}
