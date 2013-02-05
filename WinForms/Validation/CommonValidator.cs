﻿using System;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace CanteenBoard.WinForms.Validation
{
    public static class CommonValidator
    {
        private static readonly Color _invalidColor = Color.LightCoral;

        public static void ToDecimal(Control control)
        {
            control.Validated += control_Validated;
            control.Validating += control_ToDecimalValidating;
        }

        public static void NotEmpty(Control control)
        {
            control.Validated += control_Validated;
            control.Validating += control_NotEmptyValidating;
        }

        private static void control_Validated(object sender, EventArgs e)
        {
            ((Control)sender).BackColor = Color.Empty;
        }

        private static void control_ToDecimalValidating(object sender, CancelEventArgs e)
        {
            try
            {
                Convert.ToDecimal(((Control)sender).Text);
            }
            catch (Exception)
            {
                ((Control)sender).BackColor = _invalidColor;
                e.Cancel = true;
            }
        }

        private static void control_NotEmptyValidating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(((Control)sender).Text))
            {
                ((Control)sender).BackColor = _invalidColor;
                e.Cancel = true;
            }
        }
    }
}
