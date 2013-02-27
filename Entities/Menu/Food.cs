using CanteenBoard.Entities.Boards;

namespace CanteenBoard.Entities.Menu
{
    /// <summary>
    /// One food in a menu.
    /// </summary>
    public class Food
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Food" /> class.
        /// </summary>
        public Food()
        {
            // Unassigned by default
            Index = -1;
        }

        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        public Amount Amount { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the allergens.
        /// </summary>
        /// <value>
        /// The allergens.
        /// </value>
        public Allergen Allergens { get; set; }

        /// <summary>
        /// Gets or sets the index.
        /// </summary>
        /// <value>
        /// The index.
        /// </value>
        public int Index { get; set; }

        /// <summary>
        /// Gets or sets the board.
        /// </summary>
        /// <value>
        /// The board.
        /// </value>
        public BoardAssignment BoardAssignment { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Food" /> is visible.
        /// </summary>
        /// <value>
        ///   <c>true</c> if visible; otherwise, <c>false</c>.
        /// </value>
        public bool Visible { get; set; }
    }
}
