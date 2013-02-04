using System;
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
            control.Validating += control_Validating;
        }

        private static void control_Validated(object sender, EventArgs e)
        {
            ((Control)sender).BackColor = Color.Empty;
        }

        private static void control_Validating(object sender, CancelEventArgs e)
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
    }
}
