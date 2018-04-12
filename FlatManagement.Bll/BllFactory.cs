using System;
using FlatManagement.Bll.Interface;
using FlatManagement.Common;
using FlatManagement.Common.Exceptions;

namespace FlatManagement.Bll
{
	public class BllFactory : BaseFactory
	{
		#region Lazy Singleton
		private class LazySingleton
		{
			public static readonly BllFactory instance;
			static LazySingleton()
			{
				instance = new BllFactory();
			}
		}

		public static BllFactory Instance
		{
			get
			{
				return LazySingleton.instance;
			}
		}
		#endregion

		private const string LayerName = "BLL";

		public TBll Get<TBll>(params object[] parameters)
			where TBll : IModel
		{
			Type interfaceType = typeof(TBll);
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

			return (TBll)Activator.CreateInstance(implementationType, parameters);
		}
	}
}
