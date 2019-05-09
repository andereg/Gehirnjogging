using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories.Interfaces;
using Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using DB_GehirnJogging;
using System.Data.Entity;

namespace Repositories.Abstract
{
    public abstract class AbstractRepository<TEntity> : IEntityRepository<TEntity> where TEntity : class
    {

        protected readonly GehirnjoggingEntities Context;

        protected AbstractRepository(GehirnjoggingEntities context)
        {
            Context = context;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Context.Dispose();
        }

        /// <summary>
        /// Gets an entity by its id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public virtual TEntity GetById(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
            Context.SaveChanges();
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual void Delete(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
            Context.SaveChanges();
        }

        /// <summary>
        /// Lists all entities.
        /// </summary>
        /// <returns></returns>
        public virtual IList<TEntity> All()
        {
            return Context.Set<TEntity>().ToList();
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual void Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
        }
    }
}
