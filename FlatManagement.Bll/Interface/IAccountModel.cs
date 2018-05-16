using FlatManagement.Bll.Model;
using FlatManagement.Common.Bll;
using FlatManagement.Common.Dto;
using FlatManagement.Dto.Entities;

namespace FlatManagement.Bll.Interface
{
	public interface IAccountModel : IModel<Account>, IDtoList<Account>
	{
		void GetByLogin(string login);
		CheckPasswordResult CheckPassword(string passwordHash);
	}
}
