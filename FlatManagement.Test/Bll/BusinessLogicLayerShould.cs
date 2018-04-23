using System;
using FlatManagement.Bll.Interface;
using FlatManagement.Common.Bll;
using FlatManagement.Common.Services;
using FlatManagement.Test.Tools;
using Xunit;

namespace FlatManagement.Test.Bll
{
	public class BusinessLogicLayerShould : TestBase
	{
		[Fact]
		public void SerializeEmptyModels()
		{
			IPeriodTypeModel model = ServiceLocator.Instance.GetService<IPeriodTypeModel>();

			string serializedModel = ModelSerialiser.Instance.Serialise(model);
			Assert.Equal("[]", serializedModel);
		}

		[Fact]
		public void DeserializeEmptyModels()
		{
			IPeriodTypeModel model = ServiceLocator.Instance.GetService<IPeriodTypeModel>();
			string serializedModel = ModelSerialiser.Instance.Serialise(model);
			IPeriodTypeModel derializedModel = ModelSerialiser.Instance.Deserialize<IPeriodTypeModel>(serializedModel);

			Assert.Equal(model, derializedModel);
		}

		[Fact]
		public void SerializeModels()
		{
			IPeriodTypeModel model = ServiceLocator.Instance.GetService<IPeriodTypeModel>();
			model.GetAll();

			string serializedModel = ModelSerialiser.Instance.Serialise(model);
			Assert.False(String.IsNullOrEmpty(serializedModel));
		}

		[Fact]
		public void DeserializeModels()
		{
			IPeriodTypeModel model = ServiceLocator.Instance.GetService<IPeriodTypeModel>();
			model.GetAll();

			string serializedModel = ModelSerialiser.Instance.Serialise(model);
			IPeriodTypeModel derializedModel = ModelSerialiser.Instance.Deserialize<IPeriodTypeModel>(serializedModel);

			Assert.Equal(model, derializedModel);
		}
	}
}
