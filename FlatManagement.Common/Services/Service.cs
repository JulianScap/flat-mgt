using System;

namespace FlatManagement.Common.Services
{
	internal class Service
	{
		public Service(Type implementationType, ServiceMode mode)
		{
			this.ImplementationType = implementationType;
			this.Mode = mode;
		}

		public Service(Func<object> function)
		{
			this.Function = function;
			Mode = ServiceMode.Function;
		}

		public Service(object instance)
		{
			this.Instance = instance;
			Mode = ServiceMode.Singleton;
		}

		public Type ImplementationType { get; set; }
		public ServiceMode Mode { get; set; }
		public object Instance { get; set; }
		public Func<object> Function { get; set; }

		internal void SetMode(string modeAsString)
		{
			Mode = Enum.Parse<ServiceMode>(modeAsString);
		}
	}
}
