using System.Collections.Generic;

namespace CanteenBoard.Core.Meal
{
    /// <summary>
    /// Category of foods within a menu.
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Category" /> class.
        /// </summary>
        public Category()
        {
            Foods = new List<Food>();
        }

        /// <summary>
        /// Gets the foods.
        /// </summary>
        /// <value>
        /// The foods.
        /// </value>
        public List<Food> Foods { get; private set; }
    }
}
