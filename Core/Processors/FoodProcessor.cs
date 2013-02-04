using CanteenBoard.Entities.Menu;
using CanteenBoard.Repositories;
using CanteenBoard.Core.Common;

namespace CanteenBoard.Core.Processors
{
    /// <summary>
    /// Food processor.
    /// </summary>
    public class FoodProcessor : CommonProcessor<Food>, IFoodProcessor
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FoodProcessor" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public FoodProcessor(IRepository repository)
            : base(repository)
        {
        }
    }
}
