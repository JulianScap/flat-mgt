using System;
using System.Data.SqlClient;
using FlatManagement.Common.Extensions;

namespace FlatManagement.Dal.Impl
{
	public class ConnectionInfoContainer : IDisposable
	{
		public SqlConnection Connection { get; set; }
		public SqlCommand Command { get; set; }
		public SqlDataReader Reader { get; set; }

		#region IDisposable Support
		private bool disposedValue = false; // To detect redundant calls

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					Connection.SafeDispose();
					Command.SafeDispose();
					Reader.SafeDispose();

					Connection = null;
					Command = null;
					Reader = null;
				}

				disposedValue = true;
			}
		}

		// This code added to correctly implement the disposable pattern.
		public void Dispose()
		{
			// Do not change this code. Put cleanup code in Dispose(bool disposing) above.
			Dispose(true);
		}
		#endregion
	}
}
