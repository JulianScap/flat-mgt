﻿using Microsoft.Extensions.Configuration;

namespace FlatManagement.Bll.Tools
{
	public interface IModel
	{
		IConfiguration Configuration { set; }
		void GetAll();
		void DeleteAll();
		void PersistAll();
		void GetById(params object[] ids);
	}

	public interface IModel<TDto> : IModel
	{
		TDto NewInstance();
	}
}
