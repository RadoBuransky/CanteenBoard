using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics.Contracts;
using System.Drawing;

namespace CanteenBoard.WinForms.Layout
{
    public class RubberLayout
    {
        private readonly Form _form;
        private Size _originalFormSize;
        private Size _oldFormSize;

        /// <summary>
        /// Initializes a new instance of the <see cref="RubberLayout" /> class.
        /// </summary>
        /// <param name="form">The form.</param>
        public RubberLayout(Form form)
        {
            Contract.Requires(form != null);

            _form = form;
        }

        /// <summary>
        /// Inits this instance.
        /// </summary>
        public void Init()
        {
            // Save original positions and sizes
            _originalFormSize = _form.Size;
            _oldFormSize = _form.Size;
            _form.Layout += Form_Layout;
        }

        /// <summary>
        /// Resizes this instance.
        /// </summary>
        public void Form_Layout(object sender, EventArgs e)
        {
            if (sender != _form)
                return;

            double dX = (double)_form.Width / (double)_oldFormSize.Width;
            double dY = (double)_form.Height / (double)_oldFormSize.Height;

            ResizeChildren(_form, dX, dY);

            _oldFormSize = _form.Size;
        }

        /// <summary>
        /// Resizes the children.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <param name="dY">The d Y.</param>
        /// <param name="dY">The d Y.</param>
        private void ResizeChildren(Control control, double dX, double dY)
        {
            // Resize all controls
            foreach (Control c in control.Controls)
            {
                int newWidth = (int)((double)c.Width * dX);
                c.Bounds = new Rectangle(
                    (int)((double)c.Left * dX),
                    (int)((double)c.Top * dY),
                    newWidth,
                    (int)((double)c.Height * dY));

                if (c is Label)
                {
                    //StretchLabel((Label)c, newWidth, dX > 1.0f);
                    Label label = (Label)c;
                    label.Font = new Font(label.Font.FontFamily, (int)((double)label.Font.Size * dX), label.Font.Style);
                }

                ResizeChildren(c, dX, dY);
            }
        }

        /// <summary>
        /// Stretches the label.
        /// </summary>
        /// <param name="label">The label.</param>
        /// <param name="targetWidth">Width of the target.</param>
        /// <param name="grow">if set to <c>true</c> [grow].</param>
        private void StretchLabel(Label label, int targetWidth, bool grow)
        {
/*            if (label.Width == targetWidth)
                return;

            int newWidth = label.Width;
            Font newFont = label.Font;
            float delta = grow ? 0.5f : -0.5f;

            while (grow ? (newWidth < targetWidth) : (newWidth > targetWidth))
            {
                try
                {
                    newFont = new Font(label.Font.FontFamily, newFont.Size + delta, label.Font.Style);
                }
                catch (Exception)
                {
                    break;
                }

                newWidth = System.Windows.Forms.TextRenderer.MeasureText(label.Text, newFont).Width;
            }*/
        }
    }
}
