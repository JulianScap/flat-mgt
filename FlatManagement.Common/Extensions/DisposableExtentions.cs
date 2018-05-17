using System;
using FlatManagement.Common.Logging;

namespace FlatManagement.Common.Extensions
{
	public static class DisposableExtentions
	{
		public static void SafeDispose(this IDisposable that)
		{
			try
			{
				if (that != null)
				{
					that.Dispose();
				}
			}
			catch (Exception ex)
			{
				LogStuff.Log(ex);
				// Exception swallowed on purpose
			}
		}
	}
}
