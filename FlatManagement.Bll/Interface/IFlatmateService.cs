using FlatManagement.Common.Bll;
using FlatManagement.Common.Validation;
using FlatManagement.Dto.Entities;

namespace FlatManagement.Bll.Interface
{
	public interface IFlatmateService : IService<Flatmate>
	{
		ValidationResult CheckPassword(Flatmate flatmate, string passwordHash);
		void PreparePassword(Flatmate flatmate);
		void SavePassword(Flatmate flatmate);
		Flatmate GetByLogin(string login);
	}
}
