﻿using System;
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
using System.Diagnostics.Contracts;

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
        /// The board processor
        /// </summary>
        private readonly IBoardProcessor _boardProcessor;

        /// <summary>
        /// The Food panel
        /// </summary>
        private readonly FoodPanel _foodPanel;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm" /> class.
        /// </summary>
        /// <param name="foodProcessor">The food processor.</param>
        /// <param name="boardProcessor">The board processor.</param>
        public MainForm(IFoodProcessor foodProcessor, IBoardProcessor boardProcessor)
        {
            Contract.Requires(foodProcessor != null);
            Contract.Requires(boardProcessor != null);

            InitializeComponent();

            _foodProcessor = foodProcessor;
            _boardProcessor = boardProcessor;
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

        private void screenNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Board board = _boardProcessor.Get(((KeyValuePair<string, string>)screenNameComboBox.SelectedItem).Value);
            if (board != null)
            {
                foreach (KeyValuePair<string, BoardTemplate> item in boardTemplateComboBox.Items)
                {
                    if (item.Value == board.BoardTemplate)
                    {
                        boardTemplateComboBox.SelectedItem = item;
                        break;
                    }
                }
            }
            else
            {
                boardTemplateComboBox.SelectedIndex = 0;
            }
        }

        private void DisplaySettingsChanged(object sender, EventArgs e)
        {
            RefreshScreens();

            /*
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_DesktopMonitor");
            foreach (ManagementObject obj in searcher.Get())
                Console.WriteLine("PNP Device ID: {0}", obj["PNPDeviceID"]);*/
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
                    boardTemplateComboBox.Items.Add(new KeyValuePair<string, BoardTemplate>(
                        Res.BoardTemplate.ResourceManager.GetString(boardTemplate.GetType().Name), boardTemplate));
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

                /*
                foreach (Screen screen in Screen.AllScreens)
                {
                    if (screen.Primary)
                        continue;

                    screenNameComboBox.Items.Add(new KeyValuePair<string, string>(
                        string.Format("{0} {1}x{2}", screen.DeviceName, screen.Bounds.Width, screen.Bounds.Height),
                        screen.DeviceName));
                }*/

                screenNameComboBox.Items.Add(new KeyValuePair<string, string>(@"\\.\DEVICE1", @"\\.\DEVICE1"));
                screenNameComboBox.Items.Add(new KeyValuePair<string, string>(@"\\.\DEVICE2", @"\\.\DEVICE2"));
            }
            finally
            {
                screenNameComboBox.EndUpdate();
            }

            bool screenExists = screenNameComboBox.Items.Count > 0;

            if (screenExists)
            {
                screenNameComboBox.SelectedIndex = 0;
            }

            showItButton.Visible = screenExists;
            showItComboBox.Visible = screenExists;
            updateToolStripMenuItem.Visible = screenExists;
            showToolStripMenuItem.Visible = screenExists;
            screenNameLabel.Visible = screenExists;
            screenNameComboBox.Visible = screenExists;
            boardTemplateLabel.Visible = screenExists;
            boardTemplateComboBox.Visible = screenExists;
        }
    }
}
