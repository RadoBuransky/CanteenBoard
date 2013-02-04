using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using Res = CanteenBoard.WinForms.Resources;
using CanteenBoard.Entities.Menu;
using CanteenBoard.Core;
using System.Threading;
using CanteenBoard.WinForms.Validation;

namespace CanteenBoard.WinForms.Forms
{
    /// <summary>
    /// Main form window.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// The food processor
        /// </summary>
        private readonly IFoodProcessor _foodProcessor;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm" /> class.
        /// </summary>
        /// <param name="foodProcessor">The food processor.</param>
        public MainForm(IFoodProcessor foodProcessor)
        {
            InitializeComponent();

            _foodProcessor = foodProcessor;
        }

        //==========================================================================================
        // Menu
        //==========================================================================================

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //==========================================================================================
        // Controls
        //==========================================================================================

        private void MainForm_Load(object sender, EventArgs e)
        {
            InitAmountUnits();
            CommonValidator.ToDecimal(priceTextBox);
            CommonValidator.ToDecimal(amountTextBox);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
                return;

            Food food = new Food();
            food.Title = titleTextBox.Text;
            food.Category = categoryComboBox.Text;
            food.Amount = new Amount()
            {
                Value = Convert.ToDecimal(amountTextBox.Text),
                Unit = ((KeyValuePair<string, AmountUnit>)amountUnitComboBox.SelectedItem).Value
            };
            food.Price = Convert.ToDecimal(priceTextBox.Text);

            _foodProcessor.Save(food);
        }

        //==========================================================================================
        // Private methods
        //==========================================================================================

        /// <summary>
        /// Inits the amount units.
        /// </summary>
        private void InitAmountUnits()
        {
            amountUnitComboBox.DisplayMember = "Key";
            amountUnitComboBox.ValueMember = "Value";
            foreach (string name in Enum.GetNames(typeof(AmountUnit)))
            {
                amountUnitComboBox.Items.Add(new KeyValuePair<string, AmountUnit>(
                    Res.AmountUnit.ResourceManager.GetString(name),
                    (AmountUnit)Enum.Parse(typeof(AmountUnit), name)));
            }
            amountUnitComboBox.SelectedIndex = 0;
        }
    }
}
