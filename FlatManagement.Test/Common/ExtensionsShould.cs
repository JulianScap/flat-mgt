using System;
using System.Collections.Generic;
using FlatManagement.Common.Extensions;
using FlatManagement.Test.Tools;
using Xunit;

namespace FlatManagement.Test.Common
{
	public class ExtensionsShould : TestBase
	{
		[Fact]
		public void DisposeNullObjectWithoutErrors()
		{
			IDisposable disposable = null;
			disposable.SafeDispose();
			// no Assert needed
		}

		[Fact]
		public void NotRaiseExceptionOnSafeDispose()
		{
			IDisposable disposable = new ThrowOnDispose<TestDisposableException>();
			disposable.SafeDispose();
			// no Assert needed
		}

		[Fact]
		public void ReturnFalseIfACollectionIsEmpty()
		{
			IEnumerable<object> enumerable = new object[0];
			bool isEmptyResult = enumerable.IsEmpty();
			Assert.True(isEmptyResult);
		}

		[Fact]
		public void ReturnTrueIfACollectionIsNotEmpty()
		{
			IEnumerable<object> enumerable = new object[1];
			bool isEmptyResult = enumerable.IsEmpty();
			Assert.False(isEmptyResult);
		}
	}
}
