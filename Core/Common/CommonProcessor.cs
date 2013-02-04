using CanteenBoard.Repositories;

namespace CanteenBoard.Core.Common
{
    /// <summary>
    /// Common processor.
    /// </summary>
    /// <typeparam name="T">Entity type.</typeparam>
    public abstract class CommonProcessor<T> : ICommonProcessor<T> where T : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommonProcessor{T}" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public CommonProcessor(IRepository repository)
        {
            Repository = repository;
        }

        /// <summary>
        /// Saves the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual void Save(T entity)
        {
            Repository.Save(entity);
        }

        /// <summary>
        /// Gets the repository.
        /// </summary>
        /// <value>
        /// The repository.
        /// </value>
        protected IRepository Repository { get; private set; }
    }
}
