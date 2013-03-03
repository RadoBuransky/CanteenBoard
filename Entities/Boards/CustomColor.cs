using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace CanteenBoard.Entities.Boards
{
    public class CustomColor
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Key { get; set; }

        /// <summary>
        /// Gets or sets the R.
        /// </summary>
        /// <value>
        /// The R.
        /// </value>
        public int R { get; set; }

        /// <summary>
        /// Gets or sets the G.
        /// </summary>
        /// <value>
        /// The G.
        /// </value>
        public int G { get; set; }

        /// <summary>
        /// Gets or sets the B.
        /// </summary>
        /// <value>
        /// The B.
        /// </value>
        public int B { get; set; }

        /// <summary>
        /// Sets the color.
        /// </summary>
        /// <param name="color">The color.</param>
        public void SetColor(Color color)
        {
            R = color.R;
            G = color.G;
            B = color.B;
        }

        /// <summary>
        /// Colors the specified custom color.
        /// </summary>
        /// <param name="customColor">Color of the custom.</param>
        /// <returns></returns>
        public static implicit operator Color(CustomColor customColor)
        {
            return Color.FromArgb(customColor.R, customColor.G, customColor.B);
        }
    }
}
