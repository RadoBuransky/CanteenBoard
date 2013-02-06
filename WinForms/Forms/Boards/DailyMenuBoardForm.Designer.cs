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
            this._0labelFoodTitle = new System.Windows.Forms.Label();
            this._0labelFoodPrice = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _0labelWeight
            // 
            this._0labelWeight.AutoSize = true;
            this._0labelWeight.Location = new System.Drawing.Point(16, 35);
            this._0labelWeight.Name = "_0labelWeight";
            this._0labelWeight.Size = new System.Drawing.Size(100, 13);
            this._0labelWeight.TabIndex = 0;
            this._0labelWeight.Text = "Food.Amount.Value";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
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
            // _0labelFoodTitle
            // 
            this._0labelFoodTitle.AutoSize = true;
            this._0labelFoodTitle.Location = new System.Drawing.Point(190, 35);
            this._0labelFoodTitle.Name = "_0labelFoodTitle";
            this._0labelFoodTitle.Size = new System.Drawing.Size(54, 13);
            this._0labelFoodTitle.TabIndex = 1;
            this._0labelFoodTitle.Text = "Food.Title";
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
            // DailyMenuBoardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DailyMenuBoardForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DailyMenuBoardForm_MouseClick);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label _0labelWeight;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label _0labelFoodPrice;
        private System.Windows.Forms.Label _0labelFoodTitle;
    }
}