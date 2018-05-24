using FlatManagement.Common.Dal;
using FlatManagement.Dto.Entities;

namespace FlatManagement.Dal.Interface
{
	public interface IFlatmateDataAccess : IDataAccess<Flatmate>
	{
		Flatmate GetByLogin(string login);
		void SavePassword(Flatmate flatmate);
		bool Exists(Flatmate flatmate);
	}
}
