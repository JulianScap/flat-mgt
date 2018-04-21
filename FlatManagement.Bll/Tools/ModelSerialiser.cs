using System;
using FlatManagement.Common.Services;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace FlatManagement.Bll.Tools
{
	public class ModelSerialiser
	{
		#region Lazy Singleton
		private class LazySingleton
		{
			public static readonly ModelSerialiser serialiserInstance;

			static LazySingleton()
			{
				serialiserInstance = new ModelSerialiser();
			}
		}

		public static ModelSerialiser Instance
		{
			get
			{
				return LazySingleton.serialiserInstance;
			}
		}
		#endregion

		public IConfiguration Configuration { private get; set; }

		public TBll Deserialize<TBll>(string jsonObject)
			where TBll : IModel
		{
			Type type = ServiceLocator.Instance.GetImplementationType<TBll>();

			TBll result = (TBll)JsonConvert.DeserializeObject(jsonObject, type);

			result.Configuration = Configuration;

			return result;
		}

		public string Serialise<TBll>(TBll item)
		{
			return JsonConvert.SerializeObject(item);
		}
	}
}
