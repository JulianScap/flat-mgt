using FlatManagement.Common.Bll;
using FlatManagement.Common.Dto;
using FlatManagement.Common.Validation;
using FlatManagement.Dto.Entities;

namespace FlatManagement.Bll.Interface
{
	public interface IAccountModel : IModel<Account>, IDtoList<Account>
	{
		void GetByLogin(string login);
		ValidationResult CheckPassword(string passwordHash);
	}
}
