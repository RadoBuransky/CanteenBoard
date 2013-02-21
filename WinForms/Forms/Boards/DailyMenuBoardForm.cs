using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CanteenBoard.WinForms.Layout;

namespace CanteenBoard.WinForms.Forms.Boards
{
    public partial class DailyMenuBoardForm : Form
    {
        private readonly RubberLayout _rubberLayout;

        public DailyMenuBoardForm()
        {
            InitializeComponent();

            _rubberLayout = new RubberLayout(this);
            _rubberLayout.Init();
        }

        private void DailyMenuBoardForm_MouseClick(object sender, MouseEventArgs e)
        {
            Close();
        }
    }
}
