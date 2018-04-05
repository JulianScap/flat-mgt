using System;
using System.Reflection;
using FlatManagement.Common.Exceptions;
using FlatManagement.Dal.Interface;

namespace FlatManagement.Dal
{
	public class DalFactory
	{
		private class LazySingleton
		{
			public static readonly DalFactory instance;
			static LazySingleton()
			{
				instance = new DalFactory();
			}
		}

		public static DalFactory Instance
		{
			get
			{
				return LazySingleton.instance;
			}
		}

		public T Get<T>(params object[] parameters)
			where T : IDataAccess
		{
#if DEBUG
			if (!typeof(T).IsInterface)
			{
				throw new DevException("This should be an interface");
			}
#endif

			Type[] types = Assembly.GetExecutingAssembly().GetTypes();
			Type t = null;

			foreach (var type in types)
			{
				if (type.IsInterface || type.IsAbstract || type.IsEnum)
				{
					continue;
				}
				if (typeof(T).IsAssignableFrom(type))
				{
					t = type;
					break;
				}
			}

			return (T)Activator.CreateInstance(t, parameters);
		}
	}
}
