using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace CanteenBoard.WinForms.Forms.Boards
{
    public abstract class BoardSlot
    {
        private readonly Panel _panel;
        private readonly Label[] _labels;
        private bool _clean = true;

        /// <summary>
        /// Initializes a new instance of the <see cref="BoardSlot" /> class.
        /// </summary>
        /// <param name="labels">The labels.</param>
        public BoardSlot(Panel panel, params Label[] labels)
        {
            _panel = panel;
            _labels = labels;
            foreach (Label label in _labels)
                label.TextChanged += Label_TextChanged;
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

        /// <summary>
        /// Gets a value indicating whether this instance is clean.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is clean; otherwise, <c>false</c>.
        /// </value>
        public bool IsClean
        {
            get { return _clean; }
        }

        /// <summary>
        /// Sets the data.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public abstract void SetData(object entity);

        /// <summary>
        /// Clears this instance.
        /// </summary>
        public void Clear()
        {
            foreach (Label label in _labels)
                label.Text = null;

            _clean = true;
        }

        /// <summary>
        /// Handles the TextChanged event of the Label control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void Label_TextChanged(object sender, EventArgs e)
        {
            _clean = true;
            foreach (Label label in _labels)
            {
                if (!string.IsNullOrEmpty(label.Text))
                {
                    _clean = false;
                    break;
                }
            }
        }
    }
}
