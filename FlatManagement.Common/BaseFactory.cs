using System;
using System.Collections.Generic;
using System.Reflection;

namespace FlatManagement.Common
{
	public abstract class BaseFactory
	{
		protected Dictionary<string, Type> typesByName;
		private Assembly executingAssembly;

		public BaseFactory()
		{
			this.typesByName = new Dictionary<string, Type>();
			this.executingAssembly = Assembly.GetCallingAssembly();
		}

		public BaseFactory(Assembly executingAssembly)
		{
			this.typesByName = new Dictionary<string, Type>();
			this.executingAssembly = executingAssembly;
		}

		protected virtual Type GetImplementationType<TInterface>()
		{
			Type interfaceType = typeof(TInterface);
			return GetImplementationType(interfaceType);
		}

		protected virtual Type GetImplementationType(Type interfaceType)
		{
			Type implementationType = null;

			if (!this.typesByName.TryGetValue(interfaceType.FullName, out implementationType))
			{
				implementationType = GetImplementationTypeFromAssembly(interfaceType);
				this.typesByName[interfaceType.FullName] = implementationType;
			}

			return implementationType;
		}


		private Type GetImplementationTypeFromAssembly(Type interfaceType)
		{
			Type[] types = executingAssembly.GetTypes();

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
