using FlatManagement.Common.Bll;
using FlatManagement.Common.Dto;
using FlatManagement.Common.Validation;
using FlatManagement.Dto.Entities;

namespace FlatManagement.Bll.Interface
{
	public interface IFlatmateModel : IModel<Flatmate>, IDtoList<Flatmate>
	{
		void GetByLogin(string login);
		ValidationResult CheckPassword(string passwordHash);
		void PreparePassword();
		void SavePassword();
	}
}
