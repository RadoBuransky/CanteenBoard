using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CanteenBoard.Entities.Menu;
using cSouza.WinForms.Controls;
using Res = CanteenBoard.WinForms.Resources;

namespace CanteenBoard.WinForms.Forms.Boards
{
    public class FoodBoardSlot : BoardSlot
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FoodBoardSlot" /> class.
        /// </summary>
        /// <param name="panel">The panel.</param>
        /// <param name="amountLabel">The amount label.</param>
        /// <param name="nameLabel">The name label.</param>
        /// <param name="priceLabel">The price label.</param>
        public FoodBoardSlot(Panel panel, Label amountLabel, Label nameLabel, Label priceLabel)
            : base(panel, new Label[] { amountLabel, nameLabel, priceLabel })
        {
        }

        /// <summary>
        /// Sets the data.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public override void SetData(object entity)
        {
            Food food = entity as Food;
            if (food == null)
                return;

            this[0] = food.Amount.Value.ToString() + Res.AmountUnit.ResourceManager.GetString(Enum.GetName(typeof(AmountUnit), food.Amount.Unit));
            this[1] = FoodTitleWithAllergensToString(food.Title, food.Allergens);
            this[2] = PriceToString(food.Price);
        }

        /// <summary>
        /// Prices to string.
        /// </summary>
        /// <param name="price">The price.</param>
        /// <returns></returns>
        private static string PriceToString(decimal price)
        {
            return price.ToString("0.00 €");
        }

        /// <summary>
        /// Foods the title with allergens to string.
        /// </summary>
        /// <param name="foodTitle">The food title.</param>
        /// <param name="allergens">The allergens.</param>
        /// <returns></returns>
        private static string FoodTitleWithAllergensToString(string foodTitle, Allergen allergens)
        {
            return foodTitle + BorderLabel.GetSizeTag(-4) + "  " + AllergensToString(allergens);
        }

        /// <summary>
        /// Allergenses to string.
        /// </summary>
        /// <returns></returns>
        private static string AllergensToString(Allergen allergens)
        {
            StringBuilder sb = new StringBuilder();
            int allergensValue = (int)allergens;
            int value = 1;
            for (int i = 1; i <= 14; i++)
            {
                if ((allergensValue & value) != 0)
                {
                    if (sb.Length > 0)
                        sb.Append(", ");

                    sb.Append(i);
                }

                value *= 2;
            }

            return sb.ToString();
        }
    }
}
