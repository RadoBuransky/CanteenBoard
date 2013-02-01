using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Repositories;
using System.Configuration;

namespace CanteenBoard.WinForms.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            MenuRepository menuRepository = new MenuRepository();
            menuRepository.DatabaseName = ConfigurationManager.AppSettings["DbName"];
            menuRepository.ConnectionString = ConfigurationManager.ConnectionStrings["MongoDB"].ConnectionString;
            menuRepository.AddFood("Rezen");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
