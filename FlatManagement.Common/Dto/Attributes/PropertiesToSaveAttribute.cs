using System;

namespace FlatManagement.Common.Dto.Attributes
{
	[AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
	public class PropertiesToSaveAttribute : Attribute
	{
		private readonly string[] fields;

		public PropertiesToSaveAttribute(params string[] fields)
		{
			this.fields = fields;
		}

		public static string[] Get<T>()
		{
			return Get(typeof(T));
		}

		public static string[] Get(Type type)
		{
			var attribute = GetCustomAttribute(type, typeof(PropertiesToSaveAttribute)) as PropertiesToSaveAttribute;
			if (attribute == null)
			{
				return new string[0];
			} else
			{
				return attribute.fields;
			}
		}
	}
}
