using FlatManagement.Common.Dto;

namespace FlatManagement.Common.Dal
{
	public class ParametersBuilder
	{
		public static Parameter[] BuildIdParameters(IDto item)
		{
			string[] idFields = item.IdFieldNames;
			TypeEnum[] idTypes = item.IdFieldTypes;
			Parameter[] result = new Parameter[idFields.Length];

			for (int i = 0; i < result.Length; i++)
			{
				result[i] = new Parameter(idFields[i], idTypes[i], item.GetFieldValue(idFields[i]));
			}

			return result;
		}

		public static Parameter[] BuildParametersFromDto(IDto item, bool update)
		{
			string[] propertiesToSave = null;
			TypeEnum[] typesToSave = null;

			if (update)
			{
				propertiesToSave = item.AllFieldNames;
				typesToSave = item.AllFieldTypes;
			}
			else
			{
				propertiesToSave = item.DataFieldNames;
				typesToSave = item.DataFieldTypes;
			}

			Parameter[] result = new Parameter[propertiesToSave.Length];

			for (int i = 0; i < result.Length; i++)
			{
				object value = item.GetFieldValue(propertiesToSave[i]);

				result[i] = new Parameter(propertiesToSave[i], typesToSave[i], value);
			}

			return result;
		}

		public static Parameter[] BuildIdOutParameters(IDto item)
		{
			string[] idFields = item.IdFieldNames;
			TypeEnum[] idFieldsTypes = item.IdFieldTypes;

			Parameter[] result = new Parameter[idFields.Length];

			for (int i = 0; i < result.Length; i++)
			{
				result[i] = new Parameter(idFields[i], idFieldsTypes[i]);
			}

			return result;
		}
	}
}
