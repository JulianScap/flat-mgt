using FlatManagement.Common.Dto;
using Microsoft.Extensions.Configuration;

namespace FlatManagement.Common.Dal
{
	public abstract class AbstractDataAccess<TDto> : ReadOnlyAbstractDataAccess<TDto>, IDataAccess<TDto>
		where TDto : IDto, new()
	{
		protected AbstractDataAccess(IConfiguration configuration, IDatacallsHandler handler, IParametersBuilder parametersBuilder) : base(configuration, handler, parametersBuilder)
		{
		}

		public virtual void Update(TDto item)
		{
			string command = GetStoredProcedureName(OperationEnum.Update);
			Parameter[] parameters = parametersBuilder.BuildParametersFromDto(item, update: true);
			handler.Execute(command, parameters);
		}

		public virtual void Insert(TDto item)
		{
			string command = GetStoredProcedureName(OperationEnum.Insert);
			Parameter[] parameters = parametersBuilder.BuildParametersFromDto(item, update: false);
			Parameter[] outParameters = parametersBuilder.BuildIdOutParameters(item);
			handler.Execute(command, parameters, outParameters);

			foreach (Parameter parameter in outParameters)
			{
				item.SetFieldValue(parameter.Name, parameter.Value);
			}
		}

		public virtual void Delete(IDto item)
		{
			string command = GetStoredProcedureName(OperationEnum.Delete);
			Parameter[] parameters = parametersBuilder.BuildIdParameters(item);
			handler.Execute(command, parameters);
		}
	}
}
