using Microsoft.Extensions.Configuration;

namespace FlatManagement.Bll.Interface
{
	public interface IModel
	{
		IConfiguration Configuration { set; }
		void GetAll();
		void PersistAll();
		void GetById(params object[] ids);
	}

	public interface IModel<TDto> : IModel
	{
		TDto NewInstance();
	}
}
