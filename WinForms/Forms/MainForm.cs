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
            _foodPanel = new FoodPanel(this, amountUnitComboBox, allergensListBox, titleTextBox, boardGroupComboBox, amountTextBox,
                priceTextBox, showHideButton, boardGroupColorButton, foodProcessor, boardProcessor);
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
            _foodPanel.InitBoardGroupComboBox();
            InitBoardTemplates();
            InitScreens();

            CommonValidator.ToDecimal(priceTextBox);
            CommonValidator.ToDecimal(amountTextBox);
            CommonValidator.NotEmpty(titleTextBox);
        }

        public void saveButton_Click(object sender, EventArgs e)
        {
            _foodPanel.Save();
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

        private void deleteFoodButton_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void downButton_Click(object sender, EventArgs e)
        {
            SwapFood(false);
        }

        private void upButton_Click(object sender, EventArgs e)
        {
            SwapFood(true);
        }

        private void screenNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (screenNameComboBox.SelectedIndex < 0)
                return;

            ScreenTemplate screenTemplate = _boardProcessor.GetScreenTemplate(screenNameComboBox.SelectedValueKVP<string, string>());
            if (screenTemplate != null)
            {
                boardTemplateComboBox.SelectKVP<string, BoardTemplate>(bt => bt == null ? (screenTemplate.BoardTemplateName == null) : (bt.Name == screenTemplate.BoardTemplateName));
            }
            else
            {
                boardTemplateComboBox.SelectedIndex = 0;
            }
        }

        private void DisplaySettingsChanged(object sender, EventArgs e)
        {
            RefreshScreens();
        }

        private void boardTemplateComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (boardTemplateComboBox.SelectedIndex < 0)
                return;

            string screenDeviceName = screenNameComboBox.SelectedValueKVP<string, string>();

            ScreenTemplate screenTemplate = _boardProcessor.GetScreenTemplate(screenDeviceName);
            if (screenTemplate == null)
            {
                screenTemplate = new ScreenTemplate();
                screenTemplate.ScreenDeviceName = screenDeviceName;
            }

            BoardTemplate selectedBoardTemplate = boardTemplateComboBox.SelectedValueKVP<string, BoardTemplate>();
            screenTemplate.BoardTemplateName = selectedBoardTemplate == null ? null : selectedBoardTemplate.Name;

            _boardProcessor.SaveScreenTemplate(screenTemplate);
            _boardProcessor.ShowAllBoards();
            foodTreeView.SelectedNode = null;
            ReloadTree();
            _foodPanel.ClearPanel();
        }

        private void newFoodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foodTreeView.SelectedNode = null;
            upButton.Enabled = false;
            downButton.Enabled = false;
            _foodPanel.ClearPanel();
        }

        private void showHideButton_Click(object sender, EventArgs e)
        {
            _foodPanel.ShowHideToggle();
        }

        private void foodTreeView_KeyDown(object sender, KeyEventArgs e)
        {
            TreeNode selectedNode = foodTreeView.SelectedNode;
            if (selectedNode == null ||
                selectedNode.Level == 0)
                return;

            switch (e.KeyCode)
            {
                case Keys.Space:
                    _foodPanel.ShowHideToggle();
                    break;

                case Keys.Delete:
                    Delete();
                    break;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _foodPanel.Save();
        }

        private void boardGroupComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _foodPanel.boardGroupComboBox_SelectedIndexChanged(sender, e);
        }

        private void boardGroupColorButton_ColorChanged(object sender, EventArgs e)
        {
            _foodPanel.boardGroupColorButton_ColorChanged(sender, e);
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

                foreach (BoardTemplate boardTemplate in _boardProcessor.GetBoardTemplates())
                {
                    string boardTemplateName = Res.BoardTemplate.ResourceManager.GetString(boardTemplate.Name);
                    foreach (string group in boardTemplate.Groups)
                    {
                        TreeNode categoryTreeNode = new TreeNode();
                        categoryTreeNode.Text = boardTemplateName + " - " + Res.BoardTemplate.ResourceManager.GetString(group);
                        categoryTreeNode.ImageIndex = 1;
                        categoryTreeNode.SelectedImageIndex = 1;
                        foodTreeView.Nodes.Add(categoryTreeNode);

                        BoardAssignment boardAssignment = new BoardAssignment() { BoardTemplateName = boardTemplate.Name, Group = group };
                        foreach (Food food in _foodProcessor.GetFoods(boardAssignment))
                        {
                            TreeNode newNode = new TreeNode();
                            newNode.Text = food.Title;
                            newNode.ImageIndex = food.Visible ? 2 : 0;
                            newNode.SelectedImageIndex = newNode.ImageIndex;
                            categoryTreeNode.Nodes.Add(newNode);
                        }
                        categoryTreeNode.Expand();
                    }
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
            _boardProcessor.RefreshAllBoards();
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

                boardTemplateComboBox.Items.Add(new KeyValuePair<string, BoardTemplate>(null, null));
                foreach (BoardTemplate boardTemplate in _boardProcessor.GetBoardTemplates())
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

                foreach (string screenDeviceName in _boardProcessor.GetAllScreenDeviceNames())
                {
                    AddScreenToComboBox(screenDeviceName);
                }
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

            screenNameLabel.Visible = screenExists;
            screenNameComboBox.Visible = screenExists;
            boardTemplateLabel.Visible = screenExists;
            boardTemplateComboBox.Visible = screenExists;
        }

        /// <summary>
        /// Adds the screen to combo box.
        /// </summary>
        /// <param name="deviceName">Name of the device.</param>
        private void AddScreenToComboBox(string deviceName)
        {
            screenNameComboBox.Items.Add(new KeyValuePair<string, string>((screenNameComboBox.Items.Count + 1) + ": " + deviceName, deviceName));
        }

        private void Delete()
        {
            if (_foodPanel.deleteFoodButton_Click())
            {
                ReloadTree();
                _boardProcessor.RefreshAllBoards();
            }
        }
    }
}
