﻿using System.Globalization;
namespace CanteenBoard.Entities.Menu
{
    /// <summary>
    /// Amount of food with specified units.
    /// </summary>
    public class Amount
    {
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public decimal Value { get; set; }

        /// <summary>
        /// Gets or sets the unit.
        /// </summary>
        /// <value>
        /// The unit.
        /// </value>
        public AmountUnit Unit { get; set; }

        /// <summary>
        /// Strings the specified amount.
        /// </summary>
        /// <param name="amount">The amount.</param>
        /// <returns></returns>
        public static implicit operator string(Amount amount)
        {
            return amount.ToString();
        }
    }
}
