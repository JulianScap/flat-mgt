﻿using FlatManagement.Common.Dto;

namespace FlatManagement.Common.Dal
{
	public interface IDataAccess : IReadOnlyDataAccess { }

	public interface IDataAccess<TDto> : IReadOnlyDataAccess<TDto>, IDataAccess
		where TDto : IDto, new()
	{
		void Update(TDto item);
		void Insert(TDto item);
		void Delete(IDto item);
	}
}
