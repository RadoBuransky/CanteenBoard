using CanteenBoard.Core.Common;
using CanteenBoard.Entities.Menu;

namespace CanteenBoard.Core
{
    /// <summary>
    /// Food processor.
    /// </summary>
    public interface IFoodProcessor : ICommonProcessor<Food>
    {
        /// <summary>
        /// Gets the categories.
        /// </summary>
        /// <returns>Array of categories.</returns>
        string[] GetCategories();

        /// <summary>
        /// Gets the food.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <returns></returns>
        Food[] GetFood(string category);
    }
}
