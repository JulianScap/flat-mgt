using System;
using System.Collections.Generic;
using System.Reflection;
using FlatManagement.Common.Exceptions;
using FlatManagement.Dal.Interface;

namespace FlatManagement.Dal
{
	public class DalFactory
	{
		#region Lazy Singleton
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
		#endregion

		private Dictionary<string, Type> typesByName;

		public DalFactory()
		{
			typesByName = new Dictionary<string, Type>();
		}

		public T Get<T>(params object[] parameters)
			where T : IDataAccess
		{
			Type interfaceType = typeof(T);
#if DEBUG
			if (!interfaceType.IsInterface)
			{
				throw new DevException("This should be an interface");
			}
#endif
			Type implementationType = null;

			if (!typesByName.TryGetValue(interfaceType.FullName, out implementationType))
			{
				implementationType = GetImplementationType(interfaceType);
				typesByName.Add(interfaceType.FullName, implementationType);
			}

			if (implementationType == null)
			{
				throw new ImplementationNotFoundException(interfaceType, "DAL");
			}

			return (T)Activator.CreateInstance(implementationType, parameters);
		}

		private Type GetImplementationType(Type interfaceType)
		{
			Type[] types = Assembly.GetExecutingAssembly().GetTypes();

			foreach (var type in types)
			{
				if (type.IsInterface || type.IsAbstract || type.IsEnum)
				{
					continue;
				}
				else if (interfaceType.IsAssignableFrom(type))
				{
					return type;
				}
			}
			return null;
		}
	}
}
