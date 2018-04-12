using System;
using FlatManagement.Bll;
using FlatManagement.Bll.Interface;
using FlatManagement.Common.Exceptions;
using FlatManagement.Dto.Entities;
using FlatManagement.Test.Tools;
using Xunit;

namespace FlatManagement.Test.Bll
{
	public class BusinessLogicLayerShould
	{
		[Fact]
		public void HasASingleton()
		{
			BllFactory firstInstance = BllFactory.Instance;
			BllFactory secondInstance = BllFactory.Instance;

			Assert.NotNull(firstInstance);
			Assert.Same(firstInstance, secondInstance);
		}

		[Fact]
		public void ThrowAnExceptionIfImplementationNotFound()
		{
			Assert.Throws<ImplementationNotFoundException>(() => BllFactory.Instance.Get<INoImplementationModel>());
		}

		[Fact]
		public void SerializeEmptyModels()
		{
			IPeriodTypeModel model = BllFactory.Instance.Get<IPeriodTypeModel>();

			string serializedModel = BllFactory.Instance.Serialise(model);
			Assert.Equal("[]", serializedModel);
		}

		[Fact]
		public void DeserializeEmptyModels()
		{
			IPeriodTypeModel model = BllFactory.Instance.Get<IPeriodTypeModel>();
			string serializedModel = BllFactory.Instance.Serialise(model);
			IPeriodTypeModel derializedModel = BllFactory.Instance.Deserialize<IPeriodTypeModel>(serializedModel);

			Assert.Equal(model, derializedModel);
		}

		[Fact]
		public void SerializeModels()
		{
			IPeriodTypeModel model = BllFactory.Instance.Get<IPeriodTypeModel>();
			model.GetAll();

			string serializedModel = BllFactory.Instance.Serialise(model);
			Assert.False(String.IsNullOrEmpty(serializedModel));
		}

		[Fact]
		public void DeserializeModels()
		{
			IPeriodTypeModel model = BllFactory.Instance.Get<IPeriodTypeModel>();
			model.GetAll();

			string serializedModel = BllFactory.Instance.Serialise(model);
			IPeriodTypeModel derializedModel = BllFactory.Instance.Deserialize<IPeriodTypeModel>(serializedModel);

			Assert.Equal(model, derializedModel);
		}
	}
}
