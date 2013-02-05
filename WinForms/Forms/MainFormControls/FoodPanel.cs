using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CanteenBoard.Entities.Menu;
using Res = CanteenBoard.WinForms.Resources;
using CanteenBoard.Core;

namespace CanteenBoard.WinForms.Forms.MainFormControls
{
    internal class FoodPanel
    {
        private readonly MainForm _mainForm;
        private readonly ComboBox _amountUnitComboBox;
        private readonly ListBox _allergensListBox;
        private readonly TextBox _titleTextBox;
        private readonly ComboBox _categoryComboBox;
        private readonly TextBox _amountTextBox;
        private readonly TextBox _priceTextBox;

        private readonly IFoodProcessor _foodProcessor;

        private Food _food = new Food();

        /// <summary>
        /// Initializes a new instance of the <see cref="FoodPanel" /> class.
        /// </summary>
        /// <param name="mainForm">The main form.</param>
        /// <param name="amountUnitComboBox">The amount unit combo box.</param>
        /// <param name="allergensListBox">The allergens list box.</param>
        public FoodPanel(MainForm mainForm, ComboBox amountUnitComboBox, ListBox allergensListBox, TextBox titleTextBox, ComboBox categoryComboBox,
            TextBox amountTextBox, TextBox priceTextBox, IFoodProcessor foodProcessor)
        {
            _mainForm = mainForm;
            _amountUnitComboBox = amountUnitComboBox;
            _allergensListBox = allergensListBox;
            _titleTextBox = titleTextBox;
            _categoryComboBox = categoryComboBox;
            _amountTextBox = amountTextBox;
            _priceTextBox = priceTextBox;
            _foodProcessor = foodProcessor;
        }

        //==========================================================================================
        // Public methods
        //==========================================================================================

        /// <summary>
        /// Shows the food.
        /// </summary>
        /// <param name="foodTitle">The food title.</param>
        public void ShowFood(string foodTitle)
        {
            FoodToPanel(_foodProcessor.GetFood(foodTitle));
        }

        /// <summary>
        /// Inits the amount units.
        /// </summary>
        public void InitAmountUnits()
        {
            _amountUnitComboBox.DisplayMember = "Key";
            _amountUnitComboBox.ValueMember = "Value";
            foreach (string name in Enum.GetNames(typeof(AmountUnit)))
            {
                _amountUnitComboBox.Items.Add(new KeyValuePair<string, AmountUnit>(
                    Res.AmountUnit.ResourceManager.GetString(name),
                    (AmountUnit)Enum.Parse(typeof(AmountUnit), name)));
            }
            _amountUnitComboBox.SelectedIndex = 0;
        }

        /// <summary>
        /// Inits the allergens.
        /// </summary>
        public void InitAllergens()
        {
            _allergensListBox.DisplayMember = "Key";
            _allergensListBox.ValueMember = "Value";
            _allergensListBox.BeginUpdate();
            try
            {
                _allergensListBox.Items.Clear();
                int i = 1;
                foreach (string name in Enum.GetNames(typeof(Allergen)))
                {
                    Allergen value = (Allergen)Enum.Parse(typeof(Allergen), name);
                    _allergensListBox.Items.Add(new KeyValuePair<string, Allergen>(i + " - " + Res.Allergen.ResourceManager.GetString(name), value));
                    i++;
                }
            }
            finally
            {
                _allergensListBox.EndUpdate();
            }
        }

        /// <summary>
        /// Reloads the categories combo box.
        /// </summary>
        public void ReloadCategoriesComboBox()
        {
            _categoryComboBox.BeginUpdate();
            try
            {
                _categoryComboBox.Items.Clear();
                foreach (string category in _foodProcessor.GetCategories())
                {
                    _categoryComboBox.Items.Add(category);
                }
                _categoryComboBox.SelectedIndex = _categoryComboBox.Items.Count > 0 ? 0 : -1;
            }
            finally
            {
                _categoryComboBox.EndUpdate();
            }
        }

        /// <summary>
        /// Clears the panel.
        /// </summary>
        public void ClearPanel()
        {
            _food = null;
            _titleTextBox.Clear();
            _categoryComboBox.SelectedIndex = _categoryComboBox.Items.Count == 0 ? -1 : 0;
            _amountTextBox.Text = "0";
            _amountUnitComboBox.SelectedIndex = 0;
            _priceTextBox.Text = "0";
            _allergensListBox.SelectedItems.Clear();
        }

        //==========================================================================================
        // Event handlers
        //==========================================================================================

        public void saveButton_Click(object sender, EventArgs e)
        {
            if (!_mainForm.ValidateChildren())
                return;

            if (_food == null)
            {
                _food = new Food();
            }

            _food.Title = _titleTextBox.Text;
            _food.Category = _categoryComboBox.Text;
            _food.Amount = new Amount()
            {
                Value = Convert.ToDecimal(_amountTextBox.Text),
                Unit = ((KeyValuePair<string, AmountUnit>)_amountUnitComboBox.SelectedItem).Value
            };
            _food.Price = Convert.ToDecimal(_priceTextBox.Text);
            _food.Allergens = 0;
            foreach (KeyValuePair<string, Allergen> item in _allergensListBox.SelectedItems)
            {
                _food.Allergens |= item.Value;
            }

            // Save food
            _foodProcessor.Save(_food);

            // Reload controls
            _mainForm.ReloadTree();
            ReloadCategoriesComboBox();

            // Reselect combo
            _categoryComboBox.SelectedIndex = _categoryComboBox.Items.IndexOf(_food.Category);
        }

        public bool deleteFoodButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Res.Messages.DeleteText, Res.Messages.DeleteCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                return false;

            _foodProcessor.DeleteFood(_titleTextBox.Text);
            ClearPanel();

            return true;
        }

        //==========================================================================================
        // Private methods
        //==========================================================================================

        /// <summary>
        /// Foods to panel.
        /// </summary>
        /// <param name="food">The food.</param>
        private void FoodToPanel(Food food)
        {
            _food = food;

            _titleTextBox.Text = food.Title;
            _categoryComboBox.SelectedIndex = _categoryComboBox.Items.IndexOf(food.Category);
            _amountTextBox.Text = food.Amount.Value.ToString();

            for (int i = 0; i < _amountUnitComboBox.Items.Count; i++)
            {
                KeyValuePair<string, AmountUnit> item = (KeyValuePair<string, AmountUnit>)_amountUnitComboBox.Items[i];
                if (item.Value == food.Amount.Unit)
                {
                    _amountUnitComboBox.SelectedIndex = i;
                    break;
                }
            }

            _priceTextBox.Text = food.Price.ToString();

            _allergensListBox.SelectedItems.Clear();
            for (int i = 0; i < _allergensListBox.Items.Count; i++)
            {
                KeyValuePair<string, Allergen> item = (KeyValuePair<string, Allergen>)_allergensListBox.Items[i];

                if ((food.Allergens & item.Value) != 0)
                {
                    _allergensListBox.SelectedItems.Add(item);
                }
            }
        }
    }
}
