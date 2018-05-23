using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FlatManagement.Common.Dal;
using FlatManagement.Common.Dto;
using FlatManagement.Dal.Interface;
using FlatManagement.Dto.Entities;
using Microsoft.Extensions.Configuration;

namespace FlatManagement.Dal.Impl
{
	internal class FlatDataAccess : AbstractDataAccess<Flat>, IFlatDataAccess
	{
		protected FlatDataAccess(IConfiguration configuration) : base(configuration)
		{
		}

		public Flat GetById(int flatId)
		{
			return GetById(new Flat() { FlatId = flatId });
		}

		public IEnumerable<Flat> GetByLogin(string login)
		{
			DatacallsHandler handler = new DatacallsHandler(configuration);
			string command = GetStoredProcedureName(OperationEnum.Custom, "GetByLogin");
			Parameter[] parameters = new Parameter[1] {
				new Parameter("Login", TypeEnum.String, login)
			};

			IEnumerable result = handler.GetMany(command, parameters, converter);

			return result.Cast<Flat>().ToList();
		}
	}
}
