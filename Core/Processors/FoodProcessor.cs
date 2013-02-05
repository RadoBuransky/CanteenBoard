using CanteenBoard.Entities.Menu;
using CanteenBoard.Repositories;
using CanteenBoard.Core.Common;
using System.Linq;
using System.Diagnostics.Contracts;
using System;

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
        /// Saves the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public override void Save(Food entity)
        {
            Contract.Requires(entity != null);

            if (entity.Index == -1)
            {
                // Set new index as max + 1
                entity.Index = Repository.Find<Food>().Max(f => f.Index) + 1;
            }

            base.Save(entity);
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
                       orderby f.Index
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
        /// <param name="foodTitle">The food title.</param>
        public void DeleteFood(string foodTitle)
        {
            Repository.Delete<Food>(foodTitle);
        }

        /// <summary>
        /// Swaps the food.
        /// </summary>
        /// <param name="foodTitle">The food title.</param>
        /// <param name="up">if set to <c>true</c> [up].</param>
        public void SwapFood(string foodTitle, bool up)
        {
            Contract.Requires(!string.IsNullOrEmpty(foodTitle));

            // Find this food
            Food food = GetFood(foodTitle);

            Func<Food, bool> predicate = up ?
                (Func<Food, bool>)(f => f.Index < food.Index) :
                (Func<Food, bool>)(f => f.Index > food.Index);

            Food[] result = Repository.Find<Food>().Where(predicate).OrderBy(f => f.Index).ToArray();
            if (result.Length == 0)
                return;

            Food toSwap = result[up ? result.Length - 1 : 0];

            int index = toSwap.Index;
            toSwap.Index = food.Index;
            food.Index = index;

            Save(food);
            Save(toSwap);
        }
    }
}
