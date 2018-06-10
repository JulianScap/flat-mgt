using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FlatManagement.Common.Dto;
using Microsoft.Extensions.Configuration;

namespace FlatManagement.Common.Dal
{
	public abstract class ReadOnlyAbstractDataAccess<TDto> : IReadOnlyDataAccess<TDto>
		where TDto : IDto, new()
	{
		protected static readonly IDataReaderRowConverter converter;
		private static readonly ConcurrentDictionary<string, PropertyInfo> properties;
		protected readonly IConfiguration configuration;
		protected readonly IDatacallsHandler handler;
		protected readonly IParametersBuilder parametersBuilder;

		static ReadOnlyAbstractDataAccess()
		{
			converter = new DtoConverter<TDto>();
			properties = new ConcurrentDictionary<string, PropertyInfo>();
		}

		protected ReadOnlyAbstractDataAccess(IConfiguration configuration, IDatacallsHandler handler, IParametersBuilder parametersBuilder)
		{
			this.configuration = configuration;
			this.handler = handler;
			this.parametersBuilder = parametersBuilder;
		}

		public virtual IEnumerable<TDto> GetAll()
		{
			string command = GetStoredProcedureName(OperationEnum.GetAll);
			IEnumerable result = handler.GetMany(command, null, converter);
			return result.Cast<TDto>().ToList();
		}

		public TDto GetById(TDto item)
		{
			string command = GetStoredProcedureName(OperationEnum.GetById);
			Parameter[] parameters = parametersBuilder.BuildIdParameters(item);
			object result = handler.GetOne(command, parameters, converter, true);
			return (TDto)result;
		}

		public IEnumerable<TDto> GetForUser()
		{
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
