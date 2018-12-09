using AuthenticationService.BusinessLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthenticationService.BusinessLayer
{
    public interface IRepository
    { }

    public interface IRepository<T> : IRepository where T : Entity
    {
        Task<IList<T>> GetAll();
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<bool> Delete(T entity);
    }
}
