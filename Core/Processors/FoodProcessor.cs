using CanteenBoard.Entities.Menu;
using CanteenBoard.Repositories;
using CanteenBoard.Core.Common;
using System.Linq;
using System.Diagnostics.Contracts;

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
        public Food[] GetFoods(string category)
        {
            Contract.Requires(!string.IsNullOrEmpty(category));

            var food = from f in Repository.Find<Food>()
                       where f.Category == category
                       select f;

            return food.ToArray();
        }

        /// <summary>
        /// Gets the food.
        /// </summary>
        /// <param name="foodTitle">The food title.</param>
        /// <returns></returns>
        public Food GetFood(string foodTitle)
        {
            Contract.Requires(!string.IsNullOrEmpty(foodTitle));

            return Repository.Find<Food>().Where(f => f.Title == foodTitle).First();
        }

        /// <summary>
        /// Deletes the food.
        /// </summary>
        /// <param name="food">The food.</param>
        public void DeleteFood(Food food)
        {
        }
    }
}
