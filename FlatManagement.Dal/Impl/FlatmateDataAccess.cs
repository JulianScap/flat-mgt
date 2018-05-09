using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FlatManagement.Common.Dal;
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

		public IEnumerable<Flatmate> GetByNameAndFlatName(string nickname, string flatName)
		{
			DatacallsHandler handler = new DatacallsHandler(configuration);
			string command = GetStoredProcedureName(OperationEnum.Custom, "GetByNameAndFlatName");
			Parameter[] parameters = new Parameter[2]
			{
				new Parameter("Nickname", nickname),
				new Parameter("FlatName", flatName)
			};
			IEnumerable result = handler.GetMany(command, parameters, converter);

			return result.Cast<Flatmate>().ToList();
		}
	}
}
