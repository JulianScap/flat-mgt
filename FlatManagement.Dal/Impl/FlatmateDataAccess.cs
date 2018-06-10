using FlatManagement.Common.Dal;
using FlatManagement.Common.Dto;
using FlatManagement.Dal.Interface;
using FlatManagement.Dto.Entities;
using Microsoft.Extensions.Configuration;

namespace FlatManagement.Dal.Impl
{
	public class FlatmateDataAccess : AbstractDataAccess<Flatmate>, IFlatmateDataAccess
	{
		public FlatmateDataAccess(IConfiguration configuration, IDatacallsHandler handler, IParametersBuilder parametersBuilder) : base(configuration, handler, parametersBuilder)
		{
		}

		public bool Exists(Flatmate flatmate)
		{
			string command = GetStoredProcedureName(OperationEnum.Custom, "Exists");
			Parameter[] parameters = new Parameter[2] {
				new Parameter("Login", TypeEnum.String, flatmate.Login),
				new Parameter("FlatmateId", TypeEnum.Int32, flatmate.FlatmateId)
			};
			bool result = handler.GetBool(command, parameters);
			return result;
		}

		public Flatmate GetByLogin(string login)
		{
			string command = GetStoredProcedureName(OperationEnum.Custom, "GetByLogin");
			Parameter[] parameters = new Parameter[1] {
				new Parameter("Login", TypeEnum.String, login)
			};
			object result = handler.GetOne(command, parameters, converter, true);
			return (Flatmate)result;
		}

		public void SavePassword(Flatmate flatmate)
		{
			string command = GetStoredProcedureName(OperationEnum.Custom, "SavePassword");
			Parameter[] parameters = new Parameter[2] {
				new Parameter("FlatmateId", TypeEnum.Int32, flatmate.FlatmateId),
				new Parameter("Password", TypeEnum.String, flatmate.Password),
			};
			handler.Execute(command, parameters);
		}
	}
}
