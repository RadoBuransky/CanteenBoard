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
    }
}
