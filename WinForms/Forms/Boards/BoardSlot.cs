using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace CanteenBoard.WinForms.Forms.Boards
{
    public class BoardSlot
    {
        private readonly Panel _panel;
        private readonly Label[] _labels;

        /// <summary>
        /// Initializes a new instance of the <see cref="BoardSlot" /> class.
        /// </summary>
        /// <param name="labels">The labels.</param>
        public BoardSlot(Panel panel, params Label[] labels)
        {
            _panel = panel;
            _labels = labels;
        }

        /// <summary>
        /// Gets or sets the color of the background.
        /// </summary>
        /// <value>
        /// The color of the background.
        /// </value>
        public Color BackgroundColor
        {
            get { return _panel.BackColor; }
            set { _panel.BackColor = value; }
        }

        /// <summary>
        /// Gets or sets the <see cref="System.String" /> with the specified i.
        /// </summary>
        /// <value>
        /// The <see cref="System.String" />.
        /// </value>
        /// <param name="i">The i.</param>
        /// <returns></returns>
        /// <exception cref="System.IndexOutOfRangeException"></exception>
        public string this[int i]
        {
            get
            {
                if (i < 0 || i >= _labels.Length)
                    throw new IndexOutOfRangeException();

                return _labels[i].Text;
            }
            set
            {
                if (i < 0 || i >= _labels.Length)
                    throw new IndexOutOfRangeException();

                _labels[i].Text = value;
            }
        }

        /// <summary>
        /// Gets the labels.
        /// </summary>
        /// <value>
        /// The labels.
        /// </value>
        public IEnumerable<Label> Labels
        {
            get { return _labels; }
        }
    }
}
