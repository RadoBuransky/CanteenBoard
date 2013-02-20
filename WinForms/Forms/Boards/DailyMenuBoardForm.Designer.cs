namespace CanteenBoard.WinForms.Forms.Boards
{
    partial class DailyMenuBoardForm
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
            this._0labelWeight = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this._0labelFoodPrice = new System.Windows.Forms.Label();
            this._0labelFoodTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _0labelWeight
            // 
            this._0labelWeight.AutoSize = true;
            this._0labelWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._0labelWeight.Location = new System.Drawing.Point(16, 35);
            this._0labelWeight.Name = "_0labelWeight";
            this._0labelWeight.Size = new System.Drawing.Size(102, 15);
            this._0labelWeight.TabIndex = 0;
            this._0labelWeight.Text = "Food.Amount.Value";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this._0labelFoodPrice);
            this.panel1.Controls.Add(this._0labelFoodTitle);
            this.panel1.Controls.Add(this._0labelWeight);
            this.panel1.Location = new System.Drawing.Point(9, 9);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(782, 87);
            this.panel1.TabIndex = 1;
            // 
            // _0labelFoodPrice
            // 
            this._0labelFoodPrice.AutoSize = true;
            this._0labelFoodPrice.Location = new System.Drawing.Point(404, 35);
            this._0labelFoodPrice.Name = "_0labelFoodPrice";
            this._0labelFoodPrice.Size = new System.Drawing.Size(58, 13);
            this._0labelFoodPrice.TabIndex = 2;
            this._0labelFoodPrice.Text = "Food.Price";
            // 
            // _0labelFoodTitle
            // 
            this._0labelFoodTitle.AutoSize = true;
            this._0labelFoodTitle.Location = new System.Drawing.Point(190, 35);
            this._0labelFoodTitle.Name = "_0labelFoodTitle";
            this._0labelFoodTitle.Size = new System.Drawing.Size(54, 13);
            this._0labelFoodTitle.TabIndex = 1;
            this._0labelFoodTitle.Text = "Food.Title";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(329, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // DailyMenuBoardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DailyMenuBoardForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.DailyMenuBoardForm_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DailyMenuBoardForm_MouseClick);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _0labelWeight;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label _0labelFoodPrice;
        private System.Windows.Forms.Label _0labelFoodTitle;
        private System.Windows.Forms.Label label1;
    }
}