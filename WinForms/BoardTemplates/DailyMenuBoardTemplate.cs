using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CanteenBoard.Entities.Boards;
using CanteenBoard.WinForms.Forms.Boards;
using CanteenBoard.Entities.Menu;
using System.Diagnostics.Contracts;
using System.Collections;
using System.Windows.Forms;
using System.Drawing;

namespace CanteenBoard.WinForms.BoardTemplates
{
    /// <summary>
    /// Daily menu board template.
    /// </summary>
    public class DailyMenuBoardTemplate : BaseBoardTemplate
    {
        private static readonly Color FoodBackColor = Color.FromArgb(64, 64, 64);
        private static readonly Color FreeBackColor = Color.FromArgb(0, 0, 0);

        /// <summary>
        /// The daily menu group
        /// </summary>
        public const string DailyMenuGroup = "DailyMenu";

        /// <summary>
        /// Gets the groups.
        /// </summary>
        /// <value>
        /// The groups.
        /// </value>
        /// <exception cref="System.NotImplementedException"></exception>
        public override string[] Groups
        {
            get { return new [] { DailyMenuGroup } ; }
        }

        /// <summary>
        /// Gets the type of the form.
        /// </summary>
        /// <value>
        /// The type of the form.
        /// </value>
        public override Type FormType
        {
            get
            {
                return typeof(SlotsBoardForm);
            }
        }

        /// <summary>
        /// Maps the values.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <param name="form">The form.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        protected override void BoardToForm(IEnumerable entities, Form form)
        {
            SlotsBoardForm slotsForm = (SlotsBoardForm)form;

            slotsForm.ClearAll();
            for (int i = 0; i < slotsForm.Slots.Count - 1; i++)
            {
                slotsForm.Slots[i].BackgroundColor = FoodBackColor;
            }
            slotsForm.Slots[slotsForm.Slots.Count - 1].BackgroundColor = FreeBackColor;

            int index = 0;
            foreach (object entity in entities)
            {
                Food food = entity as Food;
                if (food == null)
                    continue;

                if (index >= slotsForm.Slots.Count - 1)
                    break;

                slotsForm[index][0] = food.Amount;
                slotsForm[index][1] = FoodTitleWithAllergensToString(food.Title, food.Allergens);
                slotsForm[index][2] = PriceToString(food.Price);

                index++;
            }

            slotsForm.Relayout();
        }
    }
}
