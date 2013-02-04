﻿namespace CanteenBoard.WinForms.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.foodSplitContainer = new System.Windows.Forms.SplitContainer();
            this.addNewFoodButton = new System.Windows.Forms.Button();
            this.foodTreeView = new System.Windows.Forms.TreeView();
            this.deleteFoodButton = new System.Windows.Forms.Button();
            this.euroLabel = new System.Windows.Forms.Label();
            this.priceLabel = new System.Windows.Forms.Label();
            this.priceTextBox = new System.Windows.Forms.TextBox();
            this.amountLabel = new System.Windows.Forms.Label();
            this.amountUnitComboBox = new System.Windows.Forms.ComboBox();
            this.amountTextBox = new System.Windows.Forms.TextBox();
            this.categoryComboBox = new System.Windows.Forms.ComboBox();
            this.categoryLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.foodMenuTabPage = new System.Windows.Forms.TabPage();
            this.screensTabPage = new System.Windows.Forms.TabPage();
            this.allergensListBox = new System.Windows.Forms.ListBox();
            this.allergensLabel = new System.Windows.Forms.Label();
            this.mainMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.foodSplitContainer)).BeginInit();
            this.foodSplitContainer.Panel1.SuspendLayout();
            this.foodSplitContainer.Panel2.SuspendLayout();
            this.foodSplitContainer.SuspendLayout();
            this.mainTabControl.SuspendLayout();
            this.foodMenuTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            resources.ApplyResources(this.mainMenuStrip, "mainMenuStrip");
            this.mainMenuStrip.Name = "mainMenuStrip";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // foodSplitContainer
            // 
            this.foodSplitContainer.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.foodSplitContainer, "foodSplitContainer");
            this.foodSplitContainer.Name = "foodSplitContainer";
            // 
            // foodSplitContainer.Panel1
            // 
            this.foodSplitContainer.Panel1.Controls.Add(this.addNewFoodButton);
            this.foodSplitContainer.Panel1.Controls.Add(this.foodTreeView);
            // 
            // foodSplitContainer.Panel2
            // 
            this.foodSplitContainer.Panel2.Controls.Add(this.allergensLabel);
            this.foodSplitContainer.Panel2.Controls.Add(this.allergensListBox);
            this.foodSplitContainer.Panel2.Controls.Add(this.deleteFoodButton);
            this.foodSplitContainer.Panel2.Controls.Add(this.euroLabel);
            this.foodSplitContainer.Panel2.Controls.Add(this.priceLabel);
            this.foodSplitContainer.Panel2.Controls.Add(this.priceTextBox);
            this.foodSplitContainer.Panel2.Controls.Add(this.amountLabel);
            this.foodSplitContainer.Panel2.Controls.Add(this.amountUnitComboBox);
            this.foodSplitContainer.Panel2.Controls.Add(this.amountTextBox);
            this.foodSplitContainer.Panel2.Controls.Add(this.categoryComboBox);
            this.foodSplitContainer.Panel2.Controls.Add(this.categoryLabel);
            this.foodSplitContainer.Panel2.Controls.Add(this.saveButton);
            this.foodSplitContainer.Panel2.Controls.Add(this.titleTextBox);
            this.foodSplitContainer.Panel2.Controls.Add(this.titleLabel);
            // 
            // addNewFoodButton
            // 
            resources.ApplyResources(this.addNewFoodButton, "addNewFoodButton");
            this.addNewFoodButton.Name = "addNewFoodButton";
            this.addNewFoodButton.UseVisualStyleBackColor = true;
            // 
            // foodTreeView
            // 
            resources.ApplyResources(this.foodTreeView, "foodTreeView");
            this.foodTreeView.Name = "foodTreeView";
            // 
            // deleteFoodButton
            // 
            resources.ApplyResources(this.deleteFoodButton, "deleteFoodButton");
            this.deleteFoodButton.Name = "deleteFoodButton";
            this.deleteFoodButton.UseVisualStyleBackColor = true;
            // 
            // euroLabel
            // 
            resources.ApplyResources(this.euroLabel, "euroLabel");
            this.euroLabel.Name = "euroLabel";
            // 
            // priceLabel
            // 
            resources.ApplyResources(this.priceLabel, "priceLabel");
            this.priceLabel.Name = "priceLabel";
            // 
            // priceTextBox
            // 
            resources.ApplyResources(this.priceTextBox, "priceTextBox");
            this.priceTextBox.Name = "priceTextBox";
            // 
            // amountLabel
            // 
            resources.ApplyResources(this.amountLabel, "amountLabel");
            this.amountLabel.Name = "amountLabel";
            // 
            // amountUnitComboBox
            // 
            this.amountUnitComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.amountUnitComboBox.FormattingEnabled = true;
            resources.ApplyResources(this.amountUnitComboBox, "amountUnitComboBox");
            this.amountUnitComboBox.Name = "amountUnitComboBox";
            // 
            // amountTextBox
            // 
            resources.ApplyResources(this.amountTextBox, "amountTextBox");
            this.amountTextBox.Name = "amountTextBox";
            // 
            // categoryComboBox
            // 
            resources.ApplyResources(this.categoryComboBox, "categoryComboBox");
            this.categoryComboBox.FormattingEnabled = true;
            this.categoryComboBox.Name = "categoryComboBox";
            // 
            // categoryLabel
            // 
            resources.ApplyResources(this.categoryLabel, "categoryLabel");
            this.categoryLabel.Name = "categoryLabel";
            // 
            // saveButton
            // 
            resources.ApplyResources(this.saveButton, "saveButton");
            this.saveButton.Name = "saveButton";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // titleTextBox
            // 
            resources.ApplyResources(this.titleTextBox, "titleTextBox");
            this.titleTextBox.Name = "titleTextBox";
            // 
            // titleLabel
            // 
            resources.ApplyResources(this.titleLabel, "titleLabel");
            this.titleLabel.Name = "titleLabel";
            // 
            // mainTabControl
            // 
            resources.ApplyResources(this.mainTabControl, "mainTabControl");
            this.mainTabControl.Controls.Add(this.foodMenuTabPage);
            this.mainTabControl.Controls.Add(this.screensTabPage);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            // 
            // foodMenuTabPage
            // 
            this.foodMenuTabPage.Controls.Add(this.foodSplitContainer);
            resources.ApplyResources(this.foodMenuTabPage, "foodMenuTabPage");
            this.foodMenuTabPage.Name = "foodMenuTabPage";
            this.foodMenuTabPage.UseVisualStyleBackColor = true;
            // 
            // screensTabPage
            // 
            resources.ApplyResources(this.screensTabPage, "screensTabPage");
            this.screensTabPage.Name = "screensTabPage";
            this.screensTabPage.UseVisualStyleBackColor = true;
            // 
            // allergensListBox
            // 
            this.allergensListBox.FormattingEnabled = true;
            this.allergensListBox.Items.AddRange(new object[] {
            resources.GetString("allergensListBox.Items"),
            resources.GetString("allergensListBox.Items1"),
            resources.GetString("allergensListBox.Items2"),
            resources.GetString("allergensListBox.Items3"),
            resources.GetString("allergensListBox.Items4"),
            resources.GetString("allergensListBox.Items5"),
            resources.GetString("allergensListBox.Items6"),
            resources.GetString("allergensListBox.Items7"),
            resources.GetString("allergensListBox.Items8"),
            resources.GetString("allergensListBox.Items9"),
            resources.GetString("allergensListBox.Items10"),
            resources.GetString("allergensListBox.Items11"),
            resources.GetString("allergensListBox.Items12"),
            resources.GetString("allergensListBox.Items13")});
            resources.ApplyResources(this.allergensListBox, "allergensListBox");
            this.allergensListBox.Name = "allergensListBox";
            this.allergensListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            // 
            // allergensLabel
            // 
            resources.ApplyResources(this.allergensLabel, "allergensLabel");
            this.allergensLabel.Name = "allergensLabel";
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.Controls.Add(this.mainTabControl);
            this.Controls.Add(this.mainMenuStrip);
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.foodSplitContainer.Panel1.ResumeLayout(false);
            this.foodSplitContainer.Panel2.ResumeLayout(false);
            this.foodSplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.foodSplitContainer)).EndInit();
            this.foodSplitContainer.ResumeLayout(false);
            this.mainTabControl.ResumeLayout(false);
            this.foodMenuTabPage.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.SplitContainer foodSplitContainer;
        private System.Windows.Forms.TreeView foodTreeView;
        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage foodMenuTabPage;
        private System.Windows.Forms.TabPage screensTabPage;
        private System.Windows.Forms.Button deleteFoodButton;
        private System.Windows.Forms.Button addNewFoodButton;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.ComboBox categoryComboBox;
        private System.Windows.Forms.Label categoryLabel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label euroLabel;
        private System.Windows.Forms.Label priceLabel;
        private System.Windows.Forms.TextBox priceTextBox;
        private System.Windows.Forms.Label amountLabel;
        private System.Windows.Forms.ComboBox amountUnitComboBox;
        private System.Windows.Forms.TextBox amountTextBox;
        private System.Windows.Forms.Label allergensLabel;
        private System.Windows.Forms.ListBox allergensListBox;
    }
}