using System;
using System.Collections.Concurrent;
using System.Reflection;
using FlatManagement.Common.Exceptions;
using Microsoft.Extensions.Configuration;

namespace FlatManagement.Common.Services
{
	public class ServiceLocator
	{
		#region Lazy Singleton
		private class LazySingleton
		{
			public static readonly ServiceLocator instance;
			static LazySingleton()
			{
				instance = new ServiceLocator();
			}
		}

		public static ServiceLocator Instance
		{
			get
			{
				return LazySingleton.instance;
			}
		}
		#endregion

		private ConcurrentDictionary<Type, Service> services;
		private IConfiguration configuration;
		private bool initialised = false;
		private object synclock = new object();

		public void SetConfiguration(IConfiguration configuration)
		{
			this.configuration = configuration;
		}

		internal void Initialise()
		{
			services = new ConcurrentDictionary<Type, Service>();

			ReadConfiguration();
			PrepareInstances();

			initialised = true;
		}

		private void ReadConfiguration()
		{
			int index = 0;
			string interfaceName = configuration[$"Services:Service:{index}:Interface"];

			while (!String.IsNullOrWhiteSpace(interfaceName))
			{
				Type interfaceType = Type.GetType(interfaceName);
				string typename = configuration[$"Services:Service:{index}:ImplementationType"];
				Type implementationType = Type.GetType(typename);
				string modeAsString = configuration[$"Services:Service:{index}:Mode"];
				ServiceMode mode = Enum.Parse<ServiceMode>(modeAsString);

				services.TryAdd(interfaceType, new Service(implementationType, mode));

				index += 1;
				interfaceName = configuration[$"Services:Service:{index}:Interface"];
			}
		}

		private void PrepareInstances()
		{
			foreach (Service service in services.Values)
			{
				if (service.Mode == ServiceMode.Singleton)
				{
					service.Instance = Activator.CreateInstance(service.ImplementationType, configuration);
				}
			}
		}

		private void EnsureInitialised()
		{
			if (!initialised)
			{
				lock (synclock)
				{
					if (!initialised)
					{
						if (configuration == null)
						{
							ConfigurationBuilder builder = new ConfigurationBuilder();
							builder.AddJsonFile(@"appsettings.json");
							configuration = builder.Build();
						}

						Initialise();

						initialised = true;
					}
				}
			}
		}

		public T GetService<T>()
		{
			EnsureInitialised();

			T result = default(T);
			if (!services.TryGetValue(typeof(T), out Service service))
			{
				throw new ServiceNotFoundException($"Unknown service for {typeof(T).FullName}");
			}

			switch (service.Mode)
			{
				case ServiceMode.NewInstance:
					result = (T)Activator.CreateInstance(service.ImplementationType, configuration);
					break;
				case ServiceMode.Singleton:
					result = (T)service.Instance;
					break;
				default:
					throw new ServiceNotFoundException($"Invalid service mode for {typeof(T).FullName}");
			}

			return result;
		}
	}
}
