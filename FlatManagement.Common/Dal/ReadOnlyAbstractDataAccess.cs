using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FlatManagement.Common.Dto;
using FlatManagement.Common.WebApi;
using Microsoft.Extensions.Configuration;

namespace FlatManagement.Common.Dal
{
	public abstract class ReadOnlyAbstractDataAccess<TDto> : IReadOnlyDataAccess<TDto>
		where TDto : IDto, new()
	{
		protected static readonly IDataReaderRowConverter converter;
		private static readonly ConcurrentDictionary<string, PropertyInfo> properties;
		protected IConfiguration configuration;

		static ReadOnlyAbstractDataAccess()
		{
			converter = new DtoConverter<TDto>();
			properties = new ConcurrentDictionary<string, PropertyInfo>();
		}

		protected ReadOnlyAbstractDataAccess(IConfiguration configuration)
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

		public TDto GetById(TDto item)
		{
			DatacallsHandler handler = new DatacallsHandler(configuration);
			string command = GetStoredProcedureName(OperationEnum.GetById);
			Parameter[] parameters = ParametersBuilder.BuildIdParameters(item);
			object result = handler.GetOne(command, parameters, converter, true);
			return (TDto)result;
		}

		public IEnumerable<TDto> GetForUser()
		{
			DatacallsHandler handler = new DatacallsHandler(configuration);
			string command = GetStoredProcedureName(OperationEnum.GetForUser);
			IEnumerable result = handler.GetMany(command, null, converter);
			return result.Cast<TDto>().ToList();
		}

		protected virtual string GetStoredProcedureName(OperationEnum operation, string name = null)
		{
			if (operation == OperationEnum.Custom)
			{
				return typeof(TDto).Name + "_" + name;
			}
			else
			{
				return typeof(TDto).Name + "_" + operation.ToString();
			}
		}
	}
}
