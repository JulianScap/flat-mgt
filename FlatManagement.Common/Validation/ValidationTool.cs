using System;

namespace FlatManagement.Common.Validation
{
	public class ValidationTool
	{
		public static void Required(ValidationResult result, string fieldValue, Func<string> getMessage)
		{
			if (String.IsNullOrWhiteSpace(fieldValue))
			{
				result.Add(getMessage());
			}
		}

		public static void MaxLength(ValidationResult result, string fieldValue, int maxLength, Func<string> getMessage, bool addLengthInfo = true)
		{
			if (fieldValue != null && fieldValue.Length > maxLength)
			{
				if (addLengthInfo)
				{
					result.Add($"{getMessage()} (Maximum: {maxLength})");
				}
				else
				{
					result.Add(getMessage());
				}
			}
		}

		public static void MinLength(ValidationResult result, string fieldValue, int minLength, Func<string> getMessage, bool addLengthInfo = true)
		{
			if (fieldValue != null && fieldValue.Length < minLength)
			{
				if (addLengthInfo)
				{
					result.Add($"{getMessage()} (Minimum: {minLength})");
				}
				else
				{
					result.Add(getMessage());
				}
			}
		}
	}
}
