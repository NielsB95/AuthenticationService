using AuthenticationService.BusinessLayer.Entities;
using System.Collections.Generic;

namespace AuthenticationService.DataLayer
{
	public abstract class Repository<T> : IRepository<T> where T : Entity
	{
		public T Add(T entity)
		{
			return entity;
		}

		public bool Delete(T entity)
		{
			return true;
		}

		public IList<T> GetAll()
		{
			return new List<T>();
		}

		public T Update(T entity)
		{
			return entity;
		}
	}
}
