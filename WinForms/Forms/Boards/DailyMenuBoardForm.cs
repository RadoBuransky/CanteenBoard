﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CanteenBoard.WinForms.Forms.Boards
{
    public partial class DailyMenuBoardForm : Form
    {
        public DailyMenuBoardForm()
        {
            InitializeComponent();
        }

        private void DailyMenuBoardForm_MouseClick(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }
    }
}