﻿using AuthenticationService.BusinessLayer.Entities;
using System.Collections.Generic;

namespace AuthenticationService.DataLayer
{
	public interface IRepository
	{

	}

	public interface IRepository<T> : IRepository where T : Entity
	{
		IList<T> GetAll();
		T Add(T entity);
		T Update(T entity);
		bool Delete(T entity);
	}
}
