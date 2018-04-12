using System;

namespace FlatManagement.Test.Tools
{
	public class TestDisposableClass : IDisposable
	{
		public void Dispose()
		{
			throw new TestDisposableException();
		}
	}
}
