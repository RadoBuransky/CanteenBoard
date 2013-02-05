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
using CanteenBoard.WinForms.Forms.MainFormControls;

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
        /// The Food panel
        /// </summary>
        private readonly FoodPanel _foodPanel;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm" /> class.
        /// </summary>
        /// <param name="foodProcessor">The food processor.</param>
        public MainForm(IFoodProcessor foodProcessor)
        {
            InitializeComponent();

            _foodProcessor = foodProcessor;
            _foodPanel = new FoodPanel(this, amountUnitComboBox, allergensListBox, titleTextBox, categoryComboBox, amountTextBox,
                priceTextBox, foodProcessor);
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
            _foodPanel.InitAmountUnits();
            _foodPanel.InitAllergens();
            ReloadTree();
            _foodPanel.ReloadCategoriesComboBox();

            CommonValidator.ToDecimal(priceTextBox);
            CommonValidator.ToDecimal(amountTextBox);
        }

        public void saveButton_Click(object sender, EventArgs e)
        {
            _foodPanel.saveButton_Click(sender, e);
        }

        private void foodTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Level == 0)
                return;

            _foodPanel.ShowFood(e.Node.Text);
        }

        private void addNewFoodButton_Click(object sender, EventArgs e)
        {
            _foodPanel.addNewFoodButton_Click(sender, e);
        }

        private void deleteFoodButton_Click(object sender, EventArgs e)
        {
            _foodPanel.deleteFoodButton_Click(sender, e);
        }

        //==========================================================================================
        // Private methods
        //==========================================================================================


        /// <summary>
        /// Inits the tree.
        /// </summary>
        internal void ReloadTree()
        {
            foodTreeView.BeginUpdate();
            try
            {
                foodTreeView.Nodes.Clear();
                foreach (string category in _foodProcessor.GetCategories())
                {
                    TreeNode categoryTreeNode = foodTreeView.Nodes.Add(category);
                    foreach (Food food in _foodProcessor.GetFoods(category))
                    {
                        categoryTreeNode.Nodes.Add(food.Title);
                    }
                    categoryTreeNode.Expand();
                }
            }
            finally
            {
                foodTreeView.EndUpdate();
            }
        }
    }
}
