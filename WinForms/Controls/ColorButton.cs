using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace CanteenBoard.WinForms.Controls
{
    public class ColorButton : Button
    {
        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        /// <value>
        /// The color.
        /// </value>
        public Color Color
        {
            get { return BackColor; }
            set { BackColor = value; }
        }

        /// <summary>
        /// Occurs when [color changed].
        /// </summary>
        public event EventHandler ColorChanged;

        /// <summary>
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
        protected override void OnClick(EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                colorDialog.Color = Color;
                if ((colorDialog.ShowDialog() == DialogResult.OK) &&
                    (!colorDialog.Color.Equals(Color)))
                {
                    Color = colorDialog.Color;
                    OnColorChanged(EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Raises the <see cref="E:ColorChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        protected virtual void OnColorChanged(EventArgs e)
        {
            if (ColorChanged != null)
                ColorChanged(this, e);
        }
    }
}
