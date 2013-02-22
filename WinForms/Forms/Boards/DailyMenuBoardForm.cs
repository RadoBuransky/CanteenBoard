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

        private readonly Label[][] _labels;

        public DailyMenuBoardForm()
        {
            InitializeComponent();

            _labels  = new Label[][] {
                new Label[] { amountLabel0, nameLabel0, priceLabel0 },
                new Label[] { amountLabel1, nameLabel1, priceLabel1 },
                new Label[] { amountLabel2, nameLabel2, priceLabel2 },
                new Label[] { amountLabel3, nameLabel3, priceLabel3 },
                new Label[] { amountLabel4, nameLabel4, priceLabel4 },
                new Label[] { amountLabel5, nameLabel5, priceLabel5 },
                new Label[] { amountLabel6, nameLabel6, priceLabel6 },
                new Label[] { amountLabel7, nameLabel7, priceLabel7 },
                new Label[] { amountLabel8, nameLabel8, priceLabel8 },
                new Label[] { amountLabel9, nameLabel9, priceLabel9 }
            };

            _rubberLayout = new RubberLayout(this);
            _rubberLayout.Init();
        }

        private void DailyMenuBoardForm_Layout(object sender, LayoutEventArgs e)
        {
            _rubberLayout.Relayout();
            _rubberLayout.OnesizeFitFont(_labels.SelectMany(l => l));
        }
    }
}
