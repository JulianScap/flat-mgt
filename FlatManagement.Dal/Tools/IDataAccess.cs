using System.Collections.Generic;
using FlatManagement.Common.Dto;

namespace FlatManagement.Dal.Tools
{
	public interface IDataAccess { }

	public interface IDataAccess<TDto> : IDataAccess
		where TDto : IDto, new()
	{
		IEnumerable<TDto> GetAll();
		TDto GetById(params object[] ids);
		void Update(TDto item);
		void Insert(TDto item);
	}
}
