using System;
using AuthenticationService.BusinessLayer.Entities;

namespace AuthenticationService.DataLayer
{
    public interface IRepository
    {

    }

    public interface IRepository<T> : IRepository where T : Entity
    {
        T Add(T entity);
        T Update(T entity);
        bool Delete(T entity);
    }
}
