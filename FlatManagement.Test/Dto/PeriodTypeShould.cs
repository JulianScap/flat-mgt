using System;
using FlatManagement.Dto.Entities;
using FlatManagement.Dto.Enums;
using Xunit;

namespace FlatManagement.Test.Dto
{
	public class PeriodTypeShould
	{
		[Fact]
		public void ShouldInitialiseProperly()
		{
			foreach (PeriodTypeEnum periodTypeEnum in Enum.GetValues(typeof(PeriodTypeEnum)))
			{
				PeriodType periodType = new PeriodType(periodTypeEnum);

				Assert.Equal((int)periodTypeEnum, periodType.PeriodTypeId);
				Assert.Equal(periodTypeEnum.ToString(), periodType.Name);
			}
		}

		[Fact]
		public void ShouldCompareProperly()
		{
			foreach (PeriodTypeEnum periodTypeEnum in Enum.GetValues(typeof(PeriodTypeEnum)))
			{
				PeriodType periodType = new PeriodType(periodTypeEnum);

				Assert.True(periodType.Equals(periodTypeEnum));
			}
		}

		[Fact]
		public void ShouldConvertProperly()
		{
			foreach (PeriodTypeEnum periodTypeEnum in Enum.GetValues(typeof(PeriodTypeEnum)))
			{
				PeriodType periodType = (PeriodType)periodTypeEnum;
				PeriodTypeEnum periodTypeEnumReconverted = (PeriodTypeEnum)periodType;

				Assert.True(periodType.Equals(periodTypeEnum));
				Assert.Equal(periodTypeEnum, periodTypeEnumReconverted);
			}
		}

		[Fact]
		public void ShouldFailConvertOnNull()
		{
			PeriodType pt = null;
			Assert.Throws<ArgumentNullException>("periodType", () => (PeriodTypeEnum)pt);
		}

		[Fact]
		public void ShouldFailConvertOnInvalidValue()
		{
			Assert.Throws<ArgumentException>("periodType", () => (PeriodTypeEnum)new PeriodType() { PeriodTypeId = 10000 });
		}
	}
}
