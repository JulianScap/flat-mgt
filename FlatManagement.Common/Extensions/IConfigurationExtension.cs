using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace FlatManagement.Common.Extensions
{
	public static class IConfigurationExtension
	{
		public static string[] GetStringArray(this IConfiguration that, string pattern)
		{
			if (that == null)
			{
				throw new ArgumentNullException("that");
			}

			List<string> result = new List<string>();
			int i = 0;

			string nextResult = that[String.Format(pattern, i)];
			while (nextResult != null)
			{
				result.Add(nextResult);
				i += 1;
				nextResult = that[String.Format(pattern, i)];
			}

			return result.ToArray();
		}
	}
}
