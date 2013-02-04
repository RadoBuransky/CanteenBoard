using CanteenBoard.Entities.Menu;
using CanteenBoard.Repositories;
using CanteenBoard.Core.Common;
using System.Linq;

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

        /// <summary>
        /// Gets the categories.
        /// </summary>
        /// <returns>
        /// Array of categories.
        /// </returns>
        public string[] GetCategories()
        {
            var categories = (from f in Repository.Find<Food>()
                             select f.Category).ToArray();

            return categories.Distinct().ToArray();
        }

        /// <summary>
        /// Gets the food.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <returns></returns>
        public Food[] GetFood(string category)
        {
            var food = from f in Repository.Find<Food>()
                       where f.Category == category
                       select f;

            return food.ToArray();
        }
    }
}
