using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics.Contracts;

namespace CanteenBoard.WinForms.Extensions
{
    public static class ScreenExtensions
    {
        /// <summary>
        /// Gets the name of the corrected device.
        /// </summary>
        /// <param name="screen">The screen.</param>
        /// <returns></returns>
        public static string GetCorrectedDeviceName(this Screen screen)
        {
            Contract.Requires(screen != null);

            int i = screen.DeviceName.IndexOf('\0');
            if (i > 0)
            {
                return screen.DeviceName.Substring(0, i);
            }

            return screen.DeviceName;
        }
    }
}
