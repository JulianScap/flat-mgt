using FlatManagement.Common.Dto;
using Microsoft.Extensions.Configuration;

namespace FlatManagement.Dal.Tools
{
	public abstract class AbstractDataAccess<TDto> : ReadOnlyAbstractDataAccess<TDto>, IDataAccess<TDto>
		where TDto : IDto, new()
	{
		protected AbstractDataAccess(IConfiguration configuration) : base(configuration)
		{
		}

		public virtual void Update(TDto item)
		{
			DatacallsHandler handler = new DatacallsHandler(configuration);
			string command = GetStoredProcedureName(OperationEnum.Update);
			Parameter[] parameters = ParametersBuilder.BuildParametersFromDto(item, update: true);
			handler.Execute(command, parameters);
		}

		public virtual void Insert(TDto item)
		{
			DatacallsHandler handler = new DatacallsHandler(configuration);
			string command = GetStoredProcedureName(OperationEnum.Insert);
			Parameter[] parameters = ParametersBuilder.BuildParametersFromDto(item, update: false);
			Parameter[] outParameters = ParametersBuilder.BuildIdOutParameters(item);
			handler.Execute(command, parameters, outParameters);

			foreach (Parameter parameter in outParameters)
			{
				item.SetFieldValue(parameter.Name, parameter.Value);
			}
		}

		public virtual void Delete(IDto item)
		{
			DatacallsHandler handler = new DatacallsHandler(configuration);
			string command = GetStoredProcedureName(OperationEnum.Delete);
			Parameter[] parameters = ParametersBuilder.BuildIdParameters(item);
			handler.Execute(command, parameters);
		}
	}
}
