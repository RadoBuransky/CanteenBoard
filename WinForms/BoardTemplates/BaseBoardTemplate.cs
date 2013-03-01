using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CanteenBoard.Entities.Boards;
using CanteenBoard.Entities.Menu;
using cSouza.WinForms.Controls;

namespace CanteenBoard.WinForms.BoardTemplates
{
    public abstract class BaseBoardTemplate : BoardTemplate
    {
        /// <summary>
        /// Prices to string.
        /// </summary>
        /// <param name="price">The price.</param>
        /// <returns></returns>
        protected static string PriceToString(decimal price)
        {
            return String.Format("{0:C}", price);
        }

        /// <summary>
        /// Foods the title with allergens to string.
        /// </summary>
        /// <param name="foodTitle">The food title.</param>
        /// <param name="allergens">The allergens.</param>
        /// <returns></returns>
        protected static string FoodTitleWithAllergensToString(string foodTitle, Allergen allergens)
        {
            return foodTitle + BorderLabel.GetSizeTag(-4) + "  " + AllergensToString(allergens);
        }

        /// <summary>
        /// Allergenses to string.
        /// </summary>
        /// <returns></returns>
        protected static string AllergensToString(Allergen allergens)
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
