using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FlatManagement.Common.Dto;
using FlatManagement.Dal.Interface;
using Microsoft.Extensions.Configuration;

namespace FlatManagement.Dal.Tools
{
	public abstract class AbstractDataAccess<TDto> : IDataAccess<TDto>
		where TDto : IDto, new()
	{
		private static readonly IDataReaderRowConverter converter;
		private static readonly ConcurrentDictionary<string, PropertyInfo> properties;
		private IConfiguration configuration;

		static AbstractDataAccess()
		{
			converter = new DtoConverter<TDto>();
			properties = new ConcurrentDictionary<string, PropertyInfo>();
		}

		protected AbstractDataAccess(IConfiguration configuration)
		{
			this.configuration = configuration;
		}

		public virtual IEnumerable<TDto> GetAll()
		{
			DatacallsHandler handler = new DatacallsHandler(configuration);
			string command = GetStoredProcedureName(OperationEnum.GetAll);
			IEnumerable result = handler.GetMany(command, null, converter);
			return result.Cast<TDto>().ToList();
		}

		public virtual TDto GetById(params object[] ids)
		{
			DatacallsHandler handler = new DatacallsHandler(configuration);
			string command = GetStoredProcedureName(OperationEnum.GetById);
			Parameter[] parameters = ParametersBuilder.BuildIdParameters<TDto>(ids);
			object result = handler.GetOne(command, parameters, converter, true);
			return (TDto)result;
		}

		public virtual void Update(TDto item)
		{
			DatacallsHandler handler = new DatacallsHandler(configuration);
			string command = GetStoredProcedureName(OperationEnum.Update);
			Parameter[] parameters = ParametersBuilder.BuildParametersFromDto(item, update: true);
			handler.Execute(command, parameters);
		}

		protected virtual string GetStoredProcedureName(OperationEnum operation, string name = null)
		{
			if (operation == OperationEnum.Custom)
			{
				return typeof(TDto).Name + "_Custom_" + name;
			}
			else
			{
				return typeof(TDto).Name + "_" + operation.ToString();
			}
		}
	}
}
