using Microsoft.Extensions.Configuration;

namespace FlatManagement.Bll.Interface
{
	public interface IModel
	{
		IConfiguration Configuration { set; }
	}

	public interface IModel<TDto> : IModel
	{
		void GetAll();
		void PersistAll();
		void GetById(params object[] ids);
	}
}
