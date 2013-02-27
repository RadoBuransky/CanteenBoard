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
                if (Repository.Find<Food>().Any())
                {
                    entity.Index = (from food in Repository.Find<Food>()
                                    select food.Index).Max() + 1;
                }
                else
                    entity.Index = 0;
            }

            base.Save(entity);
        }

        /// <summary>
        /// Gets the food.
        /// </summary>
        /// <param name="boardAssignment">The board assignment.</param>
        /// <returns></returns>
        public Food[] GetFoods(BoardAssignment boardAssignment)
        {
            Contract.Requires(boardAssignment != null);

            var food = from f in Repository.Find<Food>()
                       where ((f.BoardAssignment != null) &&
                              (f.BoardAssignment.BoardTemplateName == boardAssignment.BoardTemplateName) &&
                              (f.BoardAssignment.Group == boardAssignment.Group))
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

            Food[] result = Repository.Find<Food>()
                .Where(predicate)
                .Where(f => f.BoardAssignment != null &&
                    f.BoardAssignment.BoardTemplateName == food.BoardAssignment.BoardTemplateName &&
                    f.BoardAssignment.Group == food.BoardAssignment.Group)
                .OrderBy(f => f.Index)
                .ToArray();
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
