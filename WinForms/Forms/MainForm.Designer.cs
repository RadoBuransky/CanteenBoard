namespace CanteenBoard.WinForms.Forms
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.foodSplitContainer = new System.Windows.Forms.SplitContainer();
            this.upButton = new System.Windows.Forms.Button();
            this.downButton = new System.Windows.Forms.Button();
            this.foodTreeView = new System.Windows.Forms.TreeView();
            this.foodTreeImageList = new System.Windows.Forms.ImageList(this.components);
            this.freeText1Label = new System.Windows.Forms.Label();
            this.freeText2Label = new System.Windows.Forms.Label();
            this.freeText1TextBox = new System.Windows.Forms.TextBox();
            this.freeText2TextBox = new System.Windows.Forms.TextBox();
            this.showHideButton = new System.Windows.Forms.Button();
            this.boardTemplateComboBox = new System.Windows.Forms.ComboBox();
            this.boardTemplateLabel = new System.Windows.Forms.Label();
            this.screenNameComboBox = new System.Windows.Forms.ComboBox();
            this.allergensLabel = new System.Windows.Forms.Label();
            this.screenNameLabel = new System.Windows.Forms.Label();
            this.allergensListBox = new System.Windows.Forms.ListBox();
            this.deleteFoodButton = new System.Windows.Forms.Button();
            this.euroLabel = new System.Windows.Forms.Label();
            this.priceLabel = new System.Windows.Forms.Label();
            this.priceTextBox = new System.Windows.Forms.TextBox();
            this.amountLabel = new System.Windows.Forms.Label();
            this.amountUnitComboBox = new System.Windows.Forms.ComboBox();
            this.amountTextBox = new System.Windows.Forms.TextBox();
            this.boardGroupComboBox = new System.Windows.Forms.ComboBox();
            this.categoryLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newFoodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.leftPanel = new System.Windows.Forms.Panel();
            this.freeText2ColorButton = new CanteenBoard.WinForms.Controls.ColorButton();
            this.freeText1ColorButton = new CanteenBoard.WinForms.Controls.ColorButton();
            this.boardGroupColorButton = new CanteenBoard.WinForms.Controls.ColorButton();
            ((System.ComponentModel.ISupportInitialize)(this.foodSplitContainer)).BeginInit();
            this.foodSplitContainer.Panel1.SuspendLayout();
            this.foodSplitContainer.Panel2.SuspendLayout();
            this.foodSplitContainer.SuspendLayout();
            this.mainMenuStrip.SuspendLayout();
            this.leftPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // foodSplitContainer
            // 
            this.foodSplitContainer.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.foodSplitContainer, "foodSplitContainer");
            this.foodSplitContainer.Name = "foodSplitContainer";
            // 
            // foodSplitContainer.Panel1
            // 
            this.foodSplitContainer.Panel1.Controls.Add(this.upButton);
            this.foodSplitContainer.Panel1.Controls.Add(this.downButton);
            this.foodSplitContainer.Panel1.Controls.Add(this.foodTreeView);
            resources.ApplyResources(this.foodSplitContainer.Panel1, "foodSplitContainer.Panel1");
            // 
            // foodSplitContainer.Panel2
            // 
            this.foodSplitContainer.Panel2.Controls.Add(this.freeText2ColorButton);
            this.foodSplitContainer.Panel2.Controls.Add(this.freeText1ColorButton);
            this.foodSplitContainer.Panel2.Controls.Add(this.freeText1Label);
            this.foodSplitContainer.Panel2.Controls.Add(this.freeText2Label);
            this.foodSplitContainer.Panel2.Controls.Add(this.freeText1TextBox);
            this.foodSplitContainer.Panel2.Controls.Add(this.freeText2TextBox);
            this.foodSplitContainer.Panel2.Controls.Add(this.boardGroupColorButton);
            this.foodSplitContainer.Panel2.Controls.Add(this.showHideButton);
            this.foodSplitContainer.Panel2.Controls.Add(this.boardTemplateComboBox);
            this.foodSplitContainer.Panel2.Controls.Add(this.boardTemplateLabel);
            this.foodSplitContainer.Panel2.Controls.Add(this.screenNameComboBox);
            this.foodSplitContainer.Panel2.Controls.Add(this.allergensLabel);
            this.foodSplitContainer.Panel2.Controls.Add(this.screenNameLabel);
            this.foodSplitContainer.Panel2.Controls.Add(this.allergensListBox);
            this.foodSplitContainer.Panel2.Controls.Add(this.deleteFoodButton);
            this.foodSplitContainer.Panel2.Controls.Add(this.euroLabel);
            this.foodSplitContainer.Panel2.Controls.Add(this.priceLabel);
            this.foodSplitContainer.Panel2.Controls.Add(this.priceTextBox);
            this.foodSplitContainer.Panel2.Controls.Add(this.amountLabel);
            this.foodSplitContainer.Panel2.Controls.Add(this.amountUnitComboBox);
            this.foodSplitContainer.Panel2.Controls.Add(this.amountTextBox);
            this.foodSplitContainer.Panel2.Controls.Add(this.boardGroupComboBox);
            this.foodSplitContainer.Panel2.Controls.Add(this.categoryLabel);
            this.foodSplitContainer.Panel2.Controls.Add(this.saveButton);
            this.foodSplitContainer.Panel2.Controls.Add(this.titleTextBox);
            this.foodSplitContainer.Panel2.Controls.Add(this.titleLabel);
            resources.ApplyResources(this.foodSplitContainer.Panel2, "foodSplitContainer.Panel2");
            // 
            // upButton
            // 
            resources.ApplyResources(this.upButton, "upButton");
            this.upButton.Name = "upButton";
            this.upButton.UseVisualStyleBackColor = true;
            this.upButton.Click += new System.EventHandler(this.upButton_Click);
            // 
            // downButton
            // 
            resources.ApplyResources(this.downButton, "downButton");
            this.downButton.Name = "downButton";
            this.downButton.UseVisualStyleBackColor = true;
            this.downButton.Click += new System.EventHandler(this.downButton_Click);
            // 
            // foodTreeView
            // 
            resources.ApplyResources(this.foodTreeView, "foodTreeView");
            this.foodTreeView.FullRowSelect = true;
            this.foodTreeView.HideSelection = false;
            this.foodTreeView.ImageList = this.foodTreeImageList;
            this.foodTreeView.Name = "foodTreeView";
            this.foodTreeView.StateImageList = this.foodTreeImageList;
            this.foodTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.foodTreeView_AfterSelect);
            this.foodTreeView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.foodTreeView_KeyDown);
            // 
            // foodTreeImageList
            // 
            this.foodTreeImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("foodTreeImageList.ImageStream")));
            this.foodTreeImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.foodTreeImageList.Images.SetKeyName(0, "white.png");
            this.foodTreeImageList.Images.SetKeyName(1, "blackBox.png");
            this.foodTreeImageList.Images.SetKeyName(2, "redDot.png");
            // 
            // freeText1Label
            // 
            resources.ApplyResources(this.freeText1Label, "freeText1Label");
            this.freeText1Label.Name = "freeText1Label";
            // 
            // freeText2Label
            // 
            resources.ApplyResources(this.freeText2Label, "freeText2Label");
            this.freeText2Label.Name = "freeText2Label";
            // 
            // freeText1TextBox
            // 
            resources.ApplyResources(this.freeText1TextBox, "freeText1TextBox");
            this.freeText1TextBox.Name = "freeText1TextBox";
            this.freeText1TextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.freeText1TextBox_KeyDown);
            // 
            // freeText2TextBox
            // 
            resources.ApplyResources(this.freeText2TextBox, "freeText2TextBox");
            this.freeText2TextBox.Name = "freeText2TextBox";
            this.freeText2TextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.freeText2TextBox_KeyDown);
            // 
            // showHideButton
            // 
            resources.ApplyResources(this.showHideButton, "showHideButton");
            this.showHideButton.BackColor = System.Drawing.Color.Pink;
            this.showHideButton.Name = "showHideButton";
            this.showHideButton.UseVisualStyleBackColor = false;
            this.showHideButton.Click += new System.EventHandler(this.showHideButton_Click);
            // 
            // boardTemplateComboBox
            // 
            resources.ApplyResources(this.boardTemplateComboBox, "boardTemplateComboBox");
            this.boardTemplateComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boardTemplateComboBox.FormattingEnabled = true;
            this.boardTemplateComboBox.Name = "boardTemplateComboBox";
            this.boardTemplateComboBox.SelectedIndexChanged += new System.EventHandler(this.boardTemplateComboBox_SelectedIndexChanged);
            // 
            // boardTemplateLabel
            // 
            resources.ApplyResources(this.boardTemplateLabel, "boardTemplateLabel");
            this.boardTemplateLabel.Name = "boardTemplateLabel";
            // 
            // screenNameComboBox
            // 
            resources.ApplyResources(this.screenNameComboBox, "screenNameComboBox");
            this.screenNameComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.screenNameComboBox.FormattingEnabled = true;
            this.screenNameComboBox.Name = "screenNameComboBox";
            this.screenNameComboBox.SelectedIndexChanged += new System.EventHandler(this.screenNameComboBox_SelectedIndexChanged);
            // 
            // allergensLabel
            // 
            resources.ApplyResources(this.allergensLabel, "allergensLabel");
            this.allergensLabel.Name = "allergensLabel";
            // 
            // screenNameLabel
            // 
            resources.ApplyResources(this.screenNameLabel, "screenNameLabel");
            this.screenNameLabel.Name = "screenNameLabel";
            // 
            // allergensListBox
            // 
            resources.ApplyResources(this.allergensListBox, "allergensListBox");
            this.allergensListBox.FormattingEnabled = true;
            this.allergensListBox.Name = "allergensListBox";
            this.allergensListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            // 
            // deleteFoodButton
            // 
            resources.ApplyResources(this.deleteFoodButton, "deleteFoodButton");
            this.deleteFoodButton.Name = "deleteFoodButton";
            this.deleteFoodButton.UseVisualStyleBackColor = true;
            this.deleteFoodButton.Click += new System.EventHandler(this.deleteFoodButton_Click);
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
            resources.ApplyResources(this.amountUnitComboBox, "amountUnitComboBox");
            this.amountUnitComboBox.FormattingEnabled = true;
            this.amountUnitComboBox.Name = "amountUnitComboBox";
            // 
            // amountTextBox
            // 
            resources.ApplyResources(this.amountTextBox, "amountTextBox");
            this.amountTextBox.Name = "amountTextBox";
            // 
            // boardGroupComboBox
            // 
            resources.ApplyResources(this.boardGroupComboBox, "boardGroupComboBox");
            this.boardGroupComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boardGroupComboBox.FormattingEnabled = true;
            this.boardGroupComboBox.Name = "boardGroupComboBox";
            this.boardGroupComboBox.SelectedIndexChanged += new System.EventHandler(this.boardGroupComboBox_SelectedIndexChanged);
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
            // mainMenuStrip
            // 
            resources.ApplyResources(this.mainMenuStrip, "mainMenuStrip");
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.newFoodToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.mainMenuStrip.Name = "mainMenuStrip";
            // 
            // saveToolStripMenuItem
            // 
            resources.ApplyResources(this.saveToolStripMenuItem, "saveToolStripMenuItem");
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // newFoodToolStripMenuItem
            // 
            resources.ApplyResources(this.newFoodToolStripMenuItem, "newFoodToolStripMenuItem");
            this.newFoodToolStripMenuItem.Name = "newFoodToolStripMenuItem";
            this.newFoodToolStripMenuItem.Click += new System.EventHandler(this.newFoodToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // leftPanel
            // 
            this.leftPanel.Controls.Add(this.foodSplitContainer);
            resources.ApplyResources(this.leftPanel, "leftPanel");
            this.leftPanel.Name = "leftPanel";
            // 
            // freeText2ColorButton
            // 
            resources.ApplyResources(this.freeText2ColorButton, "freeText2ColorButton");
            this.freeText2ColorButton.BackColor = System.Drawing.Color.Transparent;
            this.freeText2ColorButton.Color = System.Drawing.Color.Transparent;
            this.freeText2ColorButton.Name = "freeText2ColorButton";
            this.freeText2ColorButton.UseVisualStyleBackColor = true;
            this.freeText2ColorButton.ColorChanged += new System.EventHandler(this.freeText2ColorButton_ColorChanged);
            // 
            // freeText1ColorButton
            // 
            resources.ApplyResources(this.freeText1ColorButton, "freeText1ColorButton");
            this.freeText1ColorButton.BackColor = System.Drawing.Color.Transparent;
            this.freeText1ColorButton.Color = System.Drawing.Color.Transparent;
            this.freeText1ColorButton.Name = "freeText1ColorButton";
            this.freeText1ColorButton.UseVisualStyleBackColor = true;
            this.freeText1ColorButton.ColorChanged += new System.EventHandler(this.freeText1ColorButton_ColorChanged);
            // 
            // boardGroupColorButton
            // 
            resources.ApplyResources(this.boardGroupColorButton, "boardGroupColorButton");
            this.boardGroupColorButton.BackColor = System.Drawing.Color.Transparent;
            this.boardGroupColorButton.Color = System.Drawing.Color.Transparent;
            this.boardGroupColorButton.Name = "boardGroupColorButton";
            this.boardGroupColorButton.UseVisualStyleBackColor = true;
            this.boardGroupColorButton.ColorChanged += new System.EventHandler(this.boardGroupColorButton_ColorChanged);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.Controls.Add(this.leftPanel);
            this.Controls.Add(this.mainMenuStrip);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.foodSplitContainer.Panel1.ResumeLayout(false);
            this.foodSplitContainer.Panel2.ResumeLayout(false);
            this.foodSplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.foodSplitContainer)).EndInit();
            this.foodSplitContainer.ResumeLayout(false);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.leftPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.SplitContainer foodSplitContainer;
        private System.Windows.Forms.TreeView foodTreeView;
        private System.Windows.Forms.Button deleteFoodButton;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.ComboBox boardGroupComboBox;
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
        private System.Windows.Forms.Button upButton;
        private System.Windows.Forms.Button downButton;
        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.ComboBox screenNameComboBox;
        private System.Windows.Forms.Label screenNameLabel;
        private System.Windows.Forms.ComboBox boardTemplateComboBox;
        private System.Windows.Forms.Label boardTemplateLabel;
        private System.Windows.Forms.ToolStripMenuItem newFoodToolStripMenuItem;
        private System.Windows.Forms.Button showHideButton;
        private System.Windows.Forms.ImageList foodTreeImageList;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private Controls.ColorButton boardGroupColorButton;
        private Controls.ColorButton freeText2ColorButton;
        private Controls.ColorButton freeText1ColorButton;
        private System.Windows.Forms.Label freeText1Label;
        private System.Windows.Forms.Label freeText2Label;
        private System.Windows.Forms.TextBox freeText1TextBox;
        private System.Windows.Forms.TextBox freeText2TextBox;
    }
}