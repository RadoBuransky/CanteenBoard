using System.Globalization;
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
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            string unit = AmountUnitToString(Unit);
            string value = Value.ToString("0");

            if (string.IsNullOrEmpty(unit))
                return value;

            return value + unit;
        }

        /// <summary>
        /// Strings the specified amount.
        /// </summary>
        /// <param name="amount">The amount.</param>
        /// <returns></returns>
        public static implicit operator string(Amount amount)
        {
            return amount.ToString();
        }

        /// <summary>
        /// Units to string.
        /// </summary>
        /// <param name="amountUnit">The amount unit.</param>
        private static string AmountUnitToString(AmountUnit amountUnit)
        {
            switch (amountUnit)
            {
                case AmountUnit.Grams:
                    return "g";

                case AmountUnit.Milliliters:
                    return "ml";
            }

            return string.Empty;
        }
    }
}
