using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CanteenBoard.WinForms.Layout;
using System.Collections;
using System.Diagnostics.Contracts;
using CanteenBoard.Entities.Menu;
using CanteenBoard.WinForms.BoardTemplates;
using System.Globalization;
using cSouza.WinForms.Controls;
using System.Collections.ObjectModel;

namespace CanteenBoard.WinForms.Forms.Boards
{
    public partial class SlotsBoardForm : Form
    {
        private readonly RubberLayout _rubberLayout;

        private readonly BoardSlot[] _slots;

        public SlotsBoardForm()
        {
            InitializeComponent();

            _slots = new BoardSlot[] {
                new BoardSlot(slotPanel0, amountLabel0, nameLabel0, priceLabel0 ),
                new BoardSlot(slotPanel1, amountLabel1, nameLabel1, priceLabel1 ),
                new BoardSlot(slotPanel2, amountLabel2, nameLabel2, priceLabel2 ),
                new BoardSlot(slotPanel3, amountLabel3, nameLabel3, priceLabel3 ),
                new BoardSlot(slotPanel4, amountLabel4, nameLabel4, priceLabel4 ),
                new BoardSlot(slotPanel5, amountLabel5, nameLabel5, priceLabel5 ),
                new BoardSlot(slotPanel6, amountLabel6, nameLabel6, priceLabel6 ),
                new BoardSlot(slotPanel7, amountLabel7, nameLabel7, priceLabel7 ),
                new BoardSlot(slotPanel8, amountLabel8, nameLabel8, priceLabel8 ),
                new BoardSlot(slotPanel9, freeLabel)
            };

            _rubberLayout = new RubberLayout(this);
            _rubberLayout.Init();
        }

        /// <summary>
        /// Gets the slots.
        /// </summary>
        /// <value>
        /// The slots.
        /// </value>
        public BoardSlot this[int i]
        {
            get { return _slots[i]; }
        }

        /// <summary>
        /// Gets the slots.
        /// </summary>
        /// <value>
        /// The slots.
        /// </value>
        public ReadOnlyCollection<BoardSlot> Slots
        {
            get
            {
                return _slots.ToList().AsReadOnly();
            }
        }

        /// <summary>
        /// Clears all.
        /// </summary>
        public void ClearAll()
        {
            foreach (BoardSlot slot in _slots)
            {
                foreach (Label label in slot.Labels)
                {
                    label.Text = string.Empty;
                }
            }
        }

        public void Relayout()
        {
            List<BorderLabel> labels = _slots.SelectMany(s => s.Labels).Cast<BorderLabel>().ToList();
            labels.Add(freeLabel);

            _rubberLayout.Relayout();
            _rubberLayout.OnesizeFitFont(labels);
        }

        private void DailyMenuBoardForm_Layout(object sender, LayoutEventArgs e)
        {
            Relayout();
        }
    }
}
