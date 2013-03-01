using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CanteenBoard.Entities.Menu;
using Res = CanteenBoard.WinForms.Resources;
using CanteenBoard.Core;
using CanteenBoard.Entities.Boards;
using CanteenBoard.WinForms.Extensions;
using System.Resources;

namespace CanteenBoard.WinForms.Forms.MainFormControls
{
    internal class FoodPanel
    {
        private readonly MainForm _mainForm;
        private readonly ComboBox _amountUnitComboBox;
        private readonly ListBox _allergensListBox;
        private readonly TextBox _titleTextBox;
        private readonly ComboBox _boardGroupComboBox;
        private readonly TextBox _amountTextBox;
        private readonly TextBox _priceTextBox;
        private readonly Button _showHideButton;

        private readonly IFoodProcessor _foodProcessor;
        private readonly IBoardProcessor _boardProcessor;

        private Food _food = new Food();

        /// <summary>
        /// Initializes a new instance of the <see cref="FoodPanel" /> class.
        /// </summary>
        /// <param name="mainForm">The main form.</param>
        /// <param name="amountUnitComboBox">The amount unit combo box.</param>
        /// <param name="allergensListBox">The allergens list box.</param>
        /// <param name="titleTextBox">The title text box.</param>
        /// <param name="boardGroupComboBox">The board group combo box.</param>
        /// <param name="amountTextBox">The amount text box.</param>
        /// <param name="priceTextBox">The price text box.</param>
        /// <param name="showHideButton">The show hide button.</param>
        /// <param name="foodProcessor">The food processor.</param>
        /// <param name="boardProcessor">The board processor.</param>
        public FoodPanel(MainForm mainForm, ComboBox amountUnitComboBox, ListBox allergensListBox, TextBox titleTextBox, ComboBox boardGroupComboBox,
            TextBox amountTextBox, TextBox priceTextBox, Button showHideButton, IFoodProcessor foodProcessor, IBoardProcessor boardProcessor)
        {
            _mainForm = mainForm;
            _amountUnitComboBox = amountUnitComboBox;
            _allergensListBox = allergensListBox;
            _titleTextBox = titleTextBox;
            _boardGroupComboBox = boardGroupComboBox;
            _amountTextBox = amountTextBox;
            _priceTextBox = priceTextBox;
            _showHideButton = showHideButton;
            _foodProcessor = foodProcessor;
            _boardProcessor = boardProcessor;
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
        public void InitBoardGroupComboBox()
        {
            _boardGroupComboBox.BeginUpdate();
            try
            {
                _boardGroupComboBox.DisplayMember = "Key";
                _boardGroupComboBox.ValueMember = "Value";

                // Get all boards (= screens)
                _boardGroupComboBox.Items.Clear();
                foreach (BoardTemplate boardTemplate in _boardProcessor.GetBoardTemplates())
                {
                    string boardTemplateName = Res.BoardTemplate.ResourceManager.GetString(boardTemplate.Name);

                    // Get all groups for the template
                    foreach (string group in boardTemplate.Groups)
                    {
                        string title = boardTemplateName + " - " + Res.BoardTemplate.ResourceManager.GetString(group);
                        int index = _boardGroupComboBox.AddKVP(title, new Tuple<string, string>(boardTemplate.Name, group));
                    }
                }
            }
            finally
            {
                _boardGroupComboBox.EndUpdate();
            }
        }

        /// <summary>
        /// Clears the panel.
        /// </summary>
        public void ClearPanel()
        {
            _food = null;
            _titleTextBox.Clear();
            _boardGroupComboBox.SelectedIndex = 0;
            _amountTextBox.Text = "0";
            _amountUnitComboBox.SelectedIndex = 0;
            _priceTextBox.Text = "0";
            _allergensListBox.SelectedItems.Clear();
            UpdateShowHideButton(false);
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns></returns>
        public bool Save(bool defaultVisible = false)
        {
            if (!_mainForm.ValidateChildren())
                return false;

            if (_food == null)
            {
                _food = new Food();
                _food.Visible = defaultVisible;
            }
            else
            {
                if (_food.Title != _titleTextBox.Text)
                {
                    // Title (the key) has been changed, so we need to delete old record
                    _foodProcessor.DeleteFood(_food.Title);
                }
            }

            _food.Title = _titleTextBox.Text;
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

            Tuple<string, string> selectedBoardGroup = _boardGroupComboBox.SelectedValueKVP<string, Tuple<string, string>>();
            _food.BoardAssignment = new BoardAssignment();
            _food.BoardAssignment.BoardTemplateName = selectedBoardGroup.Item1;
            _food.BoardAssignment.Group = selectedBoardGroup.Item2;

            // Save food
            _foodProcessor.Save(_food);
            _boardProcessor.RefreshAllBoards();

            // Reload controls
            _mainForm.ReloadTree();

            return true;
        }

        //==========================================================================================
        // Event handlers
        //==========================================================================================

        public bool deleteFoodButton_Click()
        {
            if (MessageBox.Show(Res.Messages.DeleteText, Res.Messages.DeleteCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                return false;

            _foodProcessor.DeleteFood(_titleTextBox.Text);
            ClearPanel();

            return true;
        }

        public void ShowHideToggle()
        {
            if (_food != null)
                _food.Visible = !_food.Visible;

            if (Save(true))
            {
                UpdateShowHideButton(_food.Visible);
            }
        }

        //==========================================================================================
        // Private methods
        //==========================================================================================

        private void UpdateShowHideButton(bool visible)
        {
            _showHideButton.Text = visible ? Res.Messages.showHideButton_Hide : Res.Messages.showHideButton_Show;
        }

        /// <summary>
        /// Foods to panel.
        /// </summary>
        /// <param name="food">The food.</param>
        private void FoodToPanel(Food food)
        {
            _food = food;

            _titleTextBox.Text = food.Title;
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

            _boardGroupComboBox.SelectKVP<string, Tuple<string, string>>(t =>
                (t.Item1 == food.BoardAssignment.BoardTemplateName) && (t.Item2 == food.BoardAssignment.Group));

            UpdateShowHideButton(food.Visible);
        }
    }
}
