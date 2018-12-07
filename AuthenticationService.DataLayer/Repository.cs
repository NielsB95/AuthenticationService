using AuthenticationService.BusinessLayer;
using AuthenticationService.BusinessLayer.Entities;
using System.Collections.Generic;

namespace AuthenticationService.DataLayer
{
	public abstract class Repository<T> : IRepository<T> where T : Entity
	{
		public virtual T Add(T entity)
		{
			return entity;
		}

		public virtual bool Delete(T entity)
		{
			return true;
		}

		public virtual IList<T> GetAll()
		{
			return new List<T>();
		}

		public virtual T Update(T entity)
		{
			return entity;
		}
	}
}
