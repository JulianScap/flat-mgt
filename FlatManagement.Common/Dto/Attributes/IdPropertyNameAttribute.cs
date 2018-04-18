using System;

namespace FlatManagement.Common.Dto.Attributes
{
	[AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
	public class IdPropertyNameAttribute : Attribute
	{
		private readonly string[] ids;

		public IdPropertyNameAttribute(params string[] ids)
		{
			this.ids = ids;
		}

		public static string[] GetIdPropertyName<T>()
		{
			return GetIdPropertyName(typeof(T));
		}

		public static string[] GetIdPropertyName(Type type)
		{
			var attribute = GetCustomAttribute(type, typeof(IdPropertyNameAttribute)) as IdPropertyNameAttribute;
			if (attribute == null)
			{
				return new string[0];
			} else
			{
				return attribute.ids;
			}
		}
	}
}
