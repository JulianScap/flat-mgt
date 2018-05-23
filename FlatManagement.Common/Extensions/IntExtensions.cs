using System;
using System.Globalization;

namespace FlatManagement.Common.Extensions
{
	public static class IntExtensions
	{
		public static string ToInvariantString(this int that)
		{
			return that.ToString(CultureInfo.InvariantCulture);
		}
		public static string ToInvariantString(this int? that)
		{
			if (that.HasValue)
			{
				return that.Value.ToString(CultureInfo.InvariantCulture);
			}
			else
			{
				return String.Empty;
			}
		}
	}
}
