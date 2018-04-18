﻿using System;

namespace FlatManagement.Common.Services
{
	internal class Service
	{
		public Service(Type implementationType, ServiceMode mode)
		{
			this.ImplementationType = implementationType;
			this.Mode = mode;
		}

		public Type ImplementationType { get; set; }
		public ServiceMode Mode { get; set; }
		public object Instance { get; set; }

		internal void SetMode(string modeAsString)
		{
			Mode = Enum.Parse<ServiceMode>(modeAsString);
		}
	}
}