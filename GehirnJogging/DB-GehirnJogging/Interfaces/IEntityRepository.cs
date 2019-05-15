using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IEntityRepository<TEntity> : IDisposable
    {
        /// <summary>
        /// Gets an entity by its id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        TEntity getById(int id);

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void add(TEntity entity);

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void delete(TEntity entity);

        /// <summary>
        /// Lists all entities.
        /// </summary>
        /// <returns></returns>
        IList<TEntity> all();

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void update(TEntity entity);
    }
}
