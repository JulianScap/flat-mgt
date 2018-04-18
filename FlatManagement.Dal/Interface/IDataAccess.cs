﻿using System.Collections.Generic;

namespace FlatManagement.Dal.Interface
{
	public interface IDataAccess { }

	public interface IDataAccess<TDto> : IDataAccess
	{
		IEnumerable<TDto> GetAll();
		TDto GetById(params object[] ids);
		void Update(TDto item);
	}
}
