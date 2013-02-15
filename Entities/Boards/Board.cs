using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CanteenBoard.Entities.Boards
{
    public class Board
    {
        /// <summary>
        /// Gets or sets the name of the screen device.
        /// </summary>
        /// <value>
        /// The name of the screen device.
        /// </value>
        public string ScreenDeviceName { get; set; }

        /// <summary>
        /// Gets or sets the board template.
        /// </summary>
        /// <value>
        /// The board template.
        /// </value>
        public BoardTemplate BoardTemplate { get; set; }

        /// <summary>
        /// Gets or sets the group data.
        /// </summary>
        /// <value>
        /// The group data.
        /// </value>
        public Dictionary<string, List<object>> GroupData { get; set;  }
    }
}
