using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CanteenBoard.Entities.Menu;

namespace CanteenBoard.WinForms.Forms.Boards
{
    /// <summary>
    /// Free text board slot.
    /// </summary>
    public class FreeBoardSlot : BoardSlot
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FreeBoardSlot" /> class.
        /// </summary>
        /// <param name="panel">The panel.</param>
        /// <param name="label">The label.</param>
        public FreeBoardSlot(Panel panel, Label label)
            : base(panel, new Label[] { label })
        {
        }

        /// <summary>
        /// Sets the data.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public override void SetData(object entity)
        {
            if (!(entity is Food))
                return;

            this[0] = ((Food)entity).Title;
        }
    }
}
