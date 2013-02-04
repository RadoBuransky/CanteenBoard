using CanteenBoard.Entities.Menu;

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
    }
}
