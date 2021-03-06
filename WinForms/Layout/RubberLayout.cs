﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics.Contracts;
using System.Drawing;
using cSouza.WinForms.Controls;

namespace CanteenBoard.WinForms.Layout
{
    public class RubberLayout
    {
        private readonly Form _form;
        private Size _originalFormSize;
        private Dictionary<string, Rectangle> _originalBounds = new Dictionary<string, Rectangle>();

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
            GetOriginalBounds(_form);
        }

        /// <summary>
        /// Called when [fit font].
        /// </summary>
        /// <param name="labels">The labels.</param>
        public void OnesizeFitFont(IEnumerable<BorderLabel> labels)
        {
            Contract.Requires(labels != null);

            Font result = null;
            foreach (BorderLabel label in labels)
            {
                Font fitFont = FitLabel(label, label.Size);
                if (fitFont == null)
                    continue;

                if ((result == null) ||
                    (fitFont.Size < result.Size))
                    result = fitFont;
            }

            if (result == null)
                return;

            // Apply resulting font to all
            foreach (BorderLabel label in labels)
            {
                label.Font = result;
            }
        }

        /// <summary>
        /// Relayouts this instance.
        /// </summary>
        public void Relayout()
        {
            double dX = (double)_form.Width / (double)_originalFormSize.Width;
            double dY = (double)_form.Height / (double)_originalFormSize.Height;

            ResizeChildren(_form, dX, dY);
        }

        /// <summary>
        /// Gets the original sizes.
        /// </summary>
        /// <param name="control">The control.</param>
        private void GetOriginalBounds(Control control)
        {
            foreach (Control child in control.Controls)
            {
                _originalBounds.Add(child.Name, child.Bounds);
                GetOriginalBounds(child);
            }
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
                Rectangle originalBounds;
                if (!_originalBounds.TryGetValue(c.Name, out originalBounds))
                    continue;

                c.Bounds = new Rectangle(
                    (int)((double)originalBounds.X * dX),
                    (int)((double)originalBounds.Y * dY),
                    (int)((double)originalBounds.Width * dX),
                    (int)((double)originalBounds.Height * dY));

                ResizeChildren(c, dX, dY);
            }
        }

        /// <summary>
        /// Fits the label.
        /// </summary>
        /// <param name="label">The label.</param>
        /// <returns></returns>
        private Font FitLabel(BorderLabel borderLabel, Size targetSize)
        {
            if (string.IsNullOrEmpty(borderLabel.Text))
                return null;

            // Measure current size
            Size size = borderLabel.GetMeasuredSize();

            bool grow = (size.Width < targetSize.Width) && (size.Height < targetSize.Height);
            float delta = grow ? 0.5f : -0.5f;

            if ((!grow) &&
                (((size.Width == targetSize.Width) && (size.Height <= targetSize.Height)) ||
                 ((size.Width <= targetSize.Width) && (size.Height == targetSize.Height))))
                return borderLabel.Font;
            
            Size newSize = size;
            Font newFont = borderLabel.Font;
            Font result;
            do
            {
                result = newFont;

                if (newFont.Size + delta <= 0f)
                    break;

                try
                {
                    newFont = new Font(borderLabel.Font.FontFamily, newFont.Size + delta, borderLabel.Font.Style);
                }
                catch (Exception)
                {
                    break;
                }

                newSize = borderLabel.GetMeasuredSize(newFont.Size);

            } while (grow ? ((newSize.Width <= targetSize.Width) && (newSize.Height <= targetSize.Height)) :
                            ((newSize.Width > targetSize.Width) || (newSize.Height > targetSize.Height)));

            return grow ? result : newFont;
        }
    }
}
