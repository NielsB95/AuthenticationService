using System;
using AuthenticationService.BusinessLayer.Entities;

namespace AuthenticationService.DataLayer
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        public T Add(T entity)
        {
            return entity;
        }

        public bool Delete(T entity)
        {
            return true;
        }

        public T Update(T entity)
        {
            return entity;
        }
    }
}
