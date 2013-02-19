using System.Collections.Generic;
namespace CanteenBoard.Core.Common
{
    /// <summary>
    /// Common processor interface.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICommonProcessor<T> where T : class
    {
        /// <summary>
        /// Saves the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Save(T entity);

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAll();
    }
}
