﻿using System.Collections.Generic;
using System.Linq;
using FlatManagement.Bll.Interface;
using FlatManagement.Common.Dto;
using FlatManagement.Dal.Interface;
using Microsoft.Extensions.Configuration;

namespace FlatManagement.Bll.Impl
{
	internal abstract class AbstractModel<TDto> : AbstractDtoList<TDto>, IModel<TDto>
		where TDto : class, new()
	{
		public IConfiguration Configuration { get; set; }

		protected AbstractModel()
		{

		}

		protected AbstractModel(IConfiguration configuration)
		{
			this.Configuration = configuration;
		}

		protected abstract IDataAccess<TDto> GetDal();

		public void GetAll()
		{
			IDataAccess<TDto> dal = GetDal();
			IEnumerable<TDto> allItems = dal.GetAll();

			base.Clear();
			base.AddRange(allItems.ToList());
		}
	}
}
