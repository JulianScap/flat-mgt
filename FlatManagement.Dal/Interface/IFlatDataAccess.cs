﻿using FlatManagement.Common.Dal;
using FlatManagement.Dto.Entities;

namespace FlatManagement.Dal.Interface
{
	public interface IFlatDataAccess : IDataAccess<Flat>
	{
		Flat GetById(int flatId);
	}
}
