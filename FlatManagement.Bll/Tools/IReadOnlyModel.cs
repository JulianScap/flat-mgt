using Microsoft.Extensions.Configuration;

namespace FlatManagement.Bll.Tools
{
	public interface IReadOnlyModel
	{
		IConfiguration Configuration { set; }
		void GetAll();
		void GetById(params object[] ids);
	}

	public interface IReadOnlyModel<TDto> : IReadOnlyModel
	{
		TDto NewInstance();
	}
}
