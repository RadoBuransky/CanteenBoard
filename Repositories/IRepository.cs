using CanteenBoard.Entities.Menu;
using System.Linq;
using System.Collections.Generic;

namespace CanteenBoard.Repositories
{
    /// <summary>
    /// Generic repository interface.
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Saves the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Save(object entity);

        /// <summary>
        /// Finds this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>Queryable interface for further usage in LINQ expression.</returns>
        IQueryable<T> Find<T>();

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectId">The object id.</param>
        void Delete<T>(string objectId);
    }
}
