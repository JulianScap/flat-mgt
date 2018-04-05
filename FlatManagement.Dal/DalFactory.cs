﻿using System;
using FlatManagement.Common;
using FlatManagement.Common.Exceptions;
using FlatManagement.Dal.Interface;

namespace FlatManagement.Dal
{
	public class DalFactory : BaseFactory
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

		private const string LayerName = "DAL";

		public TDal Get<TDal>(params object[] parameters)
			where TDal : IDataAccess
		{
			Type interfaceType = typeof(TDal);
#if DEBUG
			if (!interfaceType.IsInterface)
			{
				throw new DevException($"{interfaceType.FullName} should be an interface in the {LayerName}");
			}
#endif
			Type implementationType = base.GetImplementationType(interfaceType);

			if (implementationType == null)
			{
				throw new ImplementationNotFoundException(interfaceType, LayerName);
			}

			return (TDal)Activator.CreateInstance(implementationType, parameters);
		}
	}
}
