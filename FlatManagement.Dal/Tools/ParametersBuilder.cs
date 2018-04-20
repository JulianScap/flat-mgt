using System;
using FlatManagement.Common.Dto;
using FlatManagement.Common.Exceptions;

namespace FlatManagement.Dal.Tools
{
	internal class ParametersBuilder
	{
		// Move somewhere else
		public static Parameter[] BuildIdParameters(IDto item, params object[] ids)
		{
			string[] idFields = item.IdFieldNames;

			if (idFields.Length != ids.Length)
			{
				throw new InvalidIdException("Incorrect number of ID parameter provided");
			}

			Parameter[] result = new Parameter[idFields.Length];

			for (int i = 0; i < result.Length; i++)
			{
				result[i] = new Parameter(idFields[i], ids[i]);
			}

			return result;
		}

		// Move somewhere else
		public static Parameter[] BuildParametersFromDto(IDto item, bool update)
		{
			string[] propertiesToSave = null;

			if (update)
			{
				propertiesToSave = item.AllFieldNames;
			}
			else
			{
				propertiesToSave = item.DataFieldNames;
			}

			Parameter[] result = new Parameter[propertiesToSave.Length];

			for (int i = 0; i < result.Length; i++)
			{
				object value = item.GetFieldValue(propertiesToSave[i]);

				result[i] = new Parameter(propertiesToSave[i], value);
			}

			return result;
		}

		internal static Parameter[] BuildIdOutParameters<TDto>(TDto item)
			where TDto : IDto, new()
		{
			string[] idFields = item.IdFieldNames;
			TypeEnum[] idFieldsTypes = item.IdFieldTypes;

			Parameter[] result = new Parameter[idFields.Length];

			for (int i = 0; i < result.Length; i++)
			{
				result[i] = new Parameter() { Name = idFields[i], Type = idFieldsTypes[i] };
			}

			return result;
		}
	}
}
