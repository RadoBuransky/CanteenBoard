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
        /// Gets the food.
        /// </summary>
        /// <param name="boardAssignment">The board assignment.</param>
        /// <returns></returns>
        Food[] GetFoods(BoardAssignment boardAssignment);

        /// <summary>
        /// Gets the food.
        /// </summary>
        /// <param name="foodTitle">The food title.</param>
        /// <returns></returns>
        Food GetFood(string foodTitle);

        /// <summary>
        /// Deletes the food.
        /// </summary>
        /// <param name="foodTitle">The food title.</param>
        void DeleteFood(string foodTitle);

        /// <summary>
        /// Swaps the food.
        /// </summary>
        /// <param name="foodTitle">The food title.</param>
        /// <param name="up">if set to <c>true</c> [up].</param>
        void SwapFood(string foodTitle, bool up);
    }
}
