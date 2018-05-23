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
	internal class FlatmateDataAccess : AbstractDataAccess<Flatmate>, IFlatmateDataAccess
	{
		protected FlatmateDataAccess(IConfiguration configuration) : base(configuration)
		{
		}

		public IEnumerable<Flatmate> GetByFlat(Flat flat)
		{
			DatacallsHandler handler = new DatacallsHandler(configuration);
			string command = GetStoredProcedureName(OperationEnum.Custom, "GetByFlatId");
			Parameter[] parameters = ParametersBuilder.BuildIdParameters(flat);
			IEnumerable result = handler.GetMany(command, parameters, converter);
			return result.Cast<Flatmate>().ToList();
		}

		public Flatmate GetByLogin(string login)
		{
			DatacallsHandler handler = new DatacallsHandler(configuration);
			string command = GetStoredProcedureName(OperationEnum.Custom, "GetByLogin");
			Parameter[] parameters = new Parameter[1] {
				new Parameter("Login", TypeEnum.String, login)
			};
			object result = handler.GetOne(command, parameters, converter, true);
			return (Flatmate)result;
		}
	}
}
