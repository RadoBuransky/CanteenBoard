using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CanteenBoard.WinForms.Layout;
using System.Collections;
using System.Diagnostics.Contracts;
using CanteenBoard.Entities.Menu;
using CanteenBoard.WinForms.BoardTemplates;
using System.Globalization;

namespace CanteenBoard.WinForms.Forms.Boards
{
    public partial class SalatsBoardForm : Form
    {
        private readonly RubberLayout _rubberLayout;

        private readonly Label[][] _labels;
        private readonly Label[]_allergenLabels;

        public SalatsBoardForm()
        {
            InitializeComponent();

            _labels  = new Label[][] {
                new Label[] { amountLabel0, nameLabel0, priceLabel0 },
                new Label[] { amountLabel1, nameLabel1, priceLabel1 },
                new Label[] { amountLabel2, nameLabel2, priceLabel2 },
                new Label[] { amountLabel3, nameLabel3, priceLabel3 },
                new Label[] { amountLabel4, nameLabel4, priceLabel4 },
                new Label[] { amountLabel5, nameLabel5, priceLabel5 },
                new Label[] { amountLabel6, nameLabel6, priceLabel6 },
                new Label[] { amountLabel7, nameLabel7, priceLabel7 },
                new Label[] { amountLabel8, nameLabel8, priceLabel8 },
                new Label[] { amountLabel9, nameLabel9, priceLabel9 }
            };

            _allergenLabels = new Label[] {
                alergensLabel0,
                alergensLabel1,
                alergensLabel2,
                alergensLabel3,
                alergensLabel4,
                alergensLabel5,
                alergensLabel6,
                alergensLabel7,
                alergensLabel8,
                alergensLabel9
            };

            _rubberLayout = new RubberLayout(this);
            _rubberLayout.Init();
        }

        /// <summary>
        /// Boards to form.
        /// </summary>
        /// <param name="entities">The entities.</param>
        public void BoardToForm(IEnumerable entities)
        {
            Contract.Requires(entities != null);

            // Process all entities
            int counter = 0;
            foreach (object entity in entities)
            {
                if (!(entity is Food))
                    // Only food is supported
                    continue;

                // Cast
                Food food = (Food)entity;

                if (food.BoardAssignment == null)
                    continue;

                if (food.BoardAssignment.Group == SalatsBoardTemplate.SalatsGroup)
                {
                    SetFood(counter++, food);
                }
            }

            for (int i = counter; i < _labels.Length; i++)
                SetFood(i, null);

            Relayout();
        }

        private void SetFood(int index, Food food)
        {
            if ((index < 0) ||
                (index >= _labels.Length) ||
                (index >= _allergenLabels.Length))
                return;

            Label[] labels = _labels[index];
            if (labels.Length != 3)
                return;

            if (food == null)
            {
                labels[0].Text = string.Empty;
                labels[1].Text = string.Empty;
                labels[2].Text = string.Empty;
                _allergenLabels[index].Text = string.Empty;
                return;
            }

            labels[0].Text = food.Amount;
            labels[1].Text = food.Title;
            labels[2].Text = String.Format("{0:C}", food.Price);
            _allergenLabels[index].Text = AllergensToString(food.Allergens);
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

        private void DailyMenuBoardForm_Layout(object sender, LayoutEventArgs e)
        {
            Relayout();
        }

        private void Relayout()
        {
            _rubberLayout.Relayout();
            _rubberLayout.OnesizeFitFont(_labels.SelectMany(l => l));
            _rubberLayout.OnesizeFitFont(_allergenLabels);
        }
    }
}
