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
using Microsoft.Win32;
using CanteenBoard.Entities.Boards;

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
            InitBoardTemplates();
            InitScreens();

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

        private void button1_Click(object sender, EventArgs e)
        {
            DailyMenuBoardForm form = new DailyMenuBoardForm();
            //form.StartPosition = FormStartPosition.Manual;
            //form.SetBounds(bounds.Left, bounds.Top, bounds.Width, bounds.Height, BoundsSpecified.All);
            form.Show();
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

        private void InitScreens()
        {
            SystemEvents.DisplaySettingsChanged += DisplaySettingsChanged;
            RefreshScreens();
        }

        private void InitBoardTemplates()
        {
            boardTemplateComboBox.BeginUpdate();
            try
            {
                boardTemplateComboBox.DisplayMember = "Key";
                boardTemplateComboBox.ValueMember = "Value";
                boardTemplateComboBox.Items.Clear();

                BoardTemplate[] boardTemplates = CastleContainer.Instance.ResolveAll<BoardTemplate>();
                foreach (BoardTemplate boardTemplate in boardTemplates)
                {
                    string typeName = boardTemplate.GetType().Name;
                    boardTemplateComboBox.Items.Add(new KeyValuePair<string, string>(
                        Res.BoardTemplate.ResourceManager.GetString(typeName), typeName));
                }
            }
            finally
            {
                boardTemplateComboBox.EndUpdate();
            }
        }

        private void RefreshScreens()
        {
            screenNameComboBox.BeginUpdate();
            try
            {
                screenNameComboBox.DisplayMember = "Key";
                screenNameComboBox.ValueMember = "Value";
                screenNameComboBox.Items.Clear();
                foreach (Screen screen in Screen.AllScreens)
                {
                    if (screen.Primary)
                        continue;

                    screenNameComboBox.Items.Add(new KeyValuePair<string, string>(
                        string.Format("{0} {1}x{2}", screen.DeviceName, screen.Bounds.Width, screen.Bounds.Height),
                        screen.DeviceName));
                }
            }
            finally
            {
                screenNameComboBox.EndUpdate();
            }
        }

        private void DisplaySettingsChanged(object sender, EventArgs e)
        {
            RefreshScreens();
        }
    }
}
