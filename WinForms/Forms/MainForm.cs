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
using CanteenBoard.WinForms.Extensions;
using CanteenBoard.WinForms.Forms.Boards;

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
            CommonValidator.NotEmpty(titleTextBox);
        }

        public void saveButton_Click(object sender, EventArgs e)
        {
            _foodPanel.saveButton_Click(sender, e);
        }

        private void foodTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            upButton.Enabled = e.Node.Level != 0;
            downButton.Enabled = e.Node.Level != 0;

            if (e.Node.Level == 0)
            {
                _foodPanel.ClearPanel();
                return;
            }

            _foodPanel.ShowFood(e.Node.Text);
        }

        private void addNewFoodButton_Click(object sender, EventArgs e)
        {
            foodTreeView.SelectedNode = null;
            upButton.Enabled = false;
            downButton.Enabled = false;
            _foodPanel.ClearPanel();
        }

        private void deleteFoodButton_Click(object sender, EventArgs e)
        {
            if (_foodPanel.deleteFoodButton_Click(sender, e))
                ReloadTree();
        }

        private void downButton_Click(object sender, EventArgs e)
        {
            SwapFood(false);
        }

        private void upButton_Click(object sender, EventArgs e)
        {
            Screen[] screens = Screen.AllScreens;

            SwapFood(true);
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
                string selectedTitle = null;
                if (foodTreeView.SelectedNode != null)
                {
                    selectedTitle = foodTreeView.SelectedNode.Text;
                }
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

                bool selected = false;
                if (selectedTitle != null)
                {
                    selected = foodTreeView.Select(tn => tn.Text == selectedTitle);
                }

                upButton.Enabled = selected;
                downButton.Enabled = selected;
            }
            finally
            {
                foodTreeView.EndUpdate();
            }
        }

        private void SwapFood(bool up)
        {
            if (foodTreeView.SelectedNode == null)
            {
                return;
            }

            _foodProcessor.SwapFood(foodTreeView.SelectedNode.Text, up);
            ReloadTree();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DailyMenuBoardForm form = new DailyMenuBoardForm();
            form.Show();
        }
    }
}
