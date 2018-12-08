using AuthenticationService.BusinessLayer;
using AuthenticationService.BusinessLayer.Entities;
using AuthenticationService.DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationService.DataLayer
{
    public abstract class Repository<T> : IRepository<T> where T : Entity
    {
        private AuthenticationServiceContext context;

        public Repository(AuthenticationServiceContext context)
        {
            this.context = context;
        }

        public async virtual Task<T> Add(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            await context.AddAsync(entity);
            await context.SaveChangesAsync();

            return entity;
        }

        public async virtual Task<bool> Delete(T entity)
        {
            return await new Task<bool>(() => { return true; });
        }

        public async virtual Task<IList<T>> GetAll()
        {
            var result = context.Set<T>()
                        .ToAsyncEnumerable();

            return await result.ToList();
        }

        public async virtual Task<T> Update(T entity)
        {
            context.Update(entity);

            await context.SaveChangesAsync();

            return entity;
        }
    }
}
