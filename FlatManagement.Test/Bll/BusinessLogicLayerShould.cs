using System;
using FlatManagement.Bll.Interface;
using FlatManagement.Common.Services;
using FlatManagement.Test.Tools;
using Xunit;

namespace FlatManagement.Test.Bll
{
	public class BusinessLogicLayerShould : TestBase
	{
		/*
		[Fact]
		public void SerializeEmptyModels()
		{
			ServiceLocator.Instance.SetConfiguration(GetConfiguration());
			IPeriodTypeModel model = ServiceLocator.Instance.GetService<IPeriodTypeModel>();

			string serializedModel = ServiceLocator.Instance.Serialise(model);
			Assert.Equal("[]", serializedModel);
		}

		[Fact]
		public void DeserializeEmptyModels()
		{
			IPeriodTypeModel model = ServiceLocator.Instance.Get<IPeriodTypeModel>();
			string serializedModel = ServiceLocator.Instance.Serialise(model);
			IPeriodTypeModel derializedModel = ServiceLocator.Instance.Deserialize<IPeriodTypeModel>(serializedModel);

			Assert.Equal(model, derializedModel);
		}

		[Fact]
		public void SerializeModels()
		{
			IPeriodTypeModel model = ServiceLocator.Instance.Get<IPeriodTypeModel>();
			model.GetAll();

			string serializedModel = ServiceLocator.Instance.Serialise(model);
			Assert.False(String.IsNullOrEmpty(serializedModel));
		}

		[Fact]
		public void DeserializeModels()
		{
			IPeriodTypeModel model = ServiceLocator.Instance.Get<IPeriodTypeModel>();
			model.GetAll();

			string serializedModel = ServiceLocator.Instance.Serialise(model);
			IPeriodTypeModel derializedModel = ServiceLocator.Instance.Deserialize<IPeriodTypeModel>(serializedModel);

			Assert.Equal(model, derializedModel);
		}

		 
		 		public TBll Deserialize<TBll>(string jsonObject)
			where TBll : IModel
		{
			Type implementationType = GetImplementationType<TBll>();

			return (TBll)JsonConvert.DeserializeObject(jsonObject, implementationType);
		}

		public string Serialise<TBll>(TBll item)
			where TBll : IModel
		{
			return JsonConvert.SerializeObject(item);
		}
		 */
	}
}
