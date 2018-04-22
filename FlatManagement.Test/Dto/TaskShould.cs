using System;
using FlatManagement.Dto.Entities;
using FlatManagement.Dto.Enums;
using Xunit;

namespace FlatManagement.Test.Common
{
	public class TaskShould
	{
		[Theory]
		[InlineData(16, "Take out the rubbish bin", "On the road side, behind the flat", PeriodTypeEnum.Monthly)]
		[InlineData(1, "Spring cleaning", "Clean everything", PeriodTypeEnum.Seasonally)]
		public void HaveSameHashCodeForEqualObjects(int id, string name, string description, PeriodTypeEnum periodType)
		{
			Task task1 = new Task() { TaskId = id, Name = name, DateStart = DateTime.Today, Description = description, PeriodTypeIdAsEnum = periodType };
			Task task2 = new Task() { TaskId = id, Name = name, DateStart = DateTime.Today, Description = description, PeriodTypeIdAsEnum = periodType };

			Assert.Equal(task1, task2);
			Assert.Equal(task1.GetHashCode(), task2.GetHashCode());
		}

		[Theory]
		[InlineData(20, "Take out the rubbish bin", "On the road side, behind the flat", PeriodTypeEnum.Monthly)]
		[InlineData(10, "Spring cleaning", "Clean everything", PeriodTypeEnum.Seasonally)]
		public void HaveDifferentHashCodeForDifferentObjects(int id, string name, string description, PeriodTypeEnum periodType)
		{
			Task task1 = new Task() { TaskId = id, Name = name, DateStart = DateTime.Today, Description = description, PeriodTypeIdAsEnum = periodType };
			Task task2 = new Task() { TaskId = id, Name = name, DateStart = DateTime.Today, Description = description + " diff", PeriodTypeIdAsEnum = periodType };

			Assert.NotEqual(task1, task2);
			Assert.NotEqual(task1.GetHashCode(), task2.GetHashCode());
		}
	}
}
