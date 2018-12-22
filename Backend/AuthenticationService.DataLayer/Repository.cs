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
        protected AuthenticationServiceContext context;
        protected object lockObject = new object();

        // Interal repository for testing purposes.
        internal Repository()
        { }

        protected Repository(AuthenticationServiceContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Get all eneities from a certain type from the database
        /// </summary>
        /// <returns>The all.</returns>
        public async virtual Task<IList<T>> GetAll()
        {
            var result = context.Set<T>()
                        .ToAsyncEnumerable();

            return await result.ToList();
        }

        /// <summary>
        /// Add an entity to the database.
        /// </summary>
        /// <returns>The add.</returns>
        /// <param name="entity">Entity.</param>
        public async virtual Task<T> Add(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            await context.AddAsync(entity);
            await context.SaveChangesAsync();

            return entity;
        }

        /// <summary>
        /// Delete an entity in the database.
        /// </summary>
        /// <returns>The delete.</returns>
        /// <param name="entity">Entity.</param>
        public async virtual Task<bool> Delete(T entity)
        {
            context.Remove(entity);
            var changes = await context.SaveChangesAsync();

            // Only one item should have been affected.
            return changes == 1;
        }

        /// <summary>
        /// Update an entity in the database.
        /// </summary>
        /// <returns>The update.</returns>
        /// <param name="entity">Entity.</param>
        public async virtual Task<T> Update(T entity)
        {
            context.Update(entity);
            await context.SaveChangesAsync();

            return entity;
        }
    }
}
