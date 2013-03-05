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
        private readonly BoardSlot[] _slots;
        private readonly RubberLayout _rubberLayout;

        public SlotsBoardForm()
        {
            InitializeComponent();

            _slots = new BoardSlot[] {
                new FoodBoardSlot(slotPanel0, amountLabel0, nameLabel0, priceLabel0 ),
                new FoodBoardSlot(slotPanel1, amountLabel1, nameLabel1, priceLabel1 ),
                new FoodBoardSlot(slotPanel2, amountLabel2, nameLabel2, priceLabel2 ),
                new FoodBoardSlot(slotPanel3, amountLabel3, nameLabel3, priceLabel3 ),
                new FoodBoardSlot(slotPanel4, amountLabel4, nameLabel4, priceLabel4 ),
                new FoodBoardSlot(slotPanel5, amountLabel5, nameLabel5, priceLabel5 ),
                new FoodBoardSlot(slotPanel6, amountLabel6, nameLabel6, priceLabel6 ),
                new FoodBoardSlot(slotPanel7, amountLabel7, nameLabel7, priceLabel7 ),
                new FoodBoardSlot(slotPanel8, amountLabel8, nameLabel8, priceLabel8 ),
                new FreeBoardSlot(slotPanel9, freeLabel)
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
        /// Gets or sets the slot groups.
        /// </summary>
        /// <value>
        /// The slot groups.
        /// </value>
        public SlotGroup[] SlotGroups { get; set; }

        /// <summary>
        /// Sets the data.
        /// </summary>
        /// <param name="entities">The entities.</param>
        public void SetData(object[] entities)
        {
            Contract.Requires(entities != null);

            // Assign data to all slot groups
            foreach (SlotGroup slotGroup in SlotGroups)
                slotGroup.SetData(entities);

            Relayout();
        }

        private void Relayout()
        {
            List<BorderLabel> labels = _slots.Where(bs => bs is FoodBoardSlot).SelectMany(s => s.Labels).Cast<BorderLabel>().ToList();

            _rubberLayout.Relayout();
            _rubberLayout.OnesizeFitFont(labels);
            _rubberLayout.OnesizeFitFont(new [] { freeLabel });

            FixPanelGaps();
        }

        /// <summary>
        /// Fixes the panel gaps.
        /// </summary>
        private void FixPanelGaps()
        {
            // All slots should be aligned next to each other
            for (int i = 0; i < _slots.Length - 1; i++)
            {
                _slots[i].Panel.Height = _slots[i + 1].Panel.Top - _slots[i].Panel.Top;
            }
        }

        private void DailyMenuBoardForm_Layout(object sender, LayoutEventArgs e)
        {
            Relayout();
        }
    }
}
