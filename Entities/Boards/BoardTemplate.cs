using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics.Contracts;
using System.Collections;
using System.Drawing;

namespace CanteenBoard.Entities.Boards
{
    /// <summary>
    /// Logical screen.
    /// </summary>
    public abstract class BoardTemplate
    {
        /// <summary>
        /// The _form
        /// </summary>
        private Form _form;

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name
        {
            get { return GetType().Name; }
        }

        /// <summary>
        /// Gets the groups.
        /// </summary>
        /// <value>
        /// The groups.
        /// </value>
        public abstract string[] Groups { get; }

        /// <summary>
        /// Gets the type of the form.
        /// </summary>
        /// <value>
        /// The type of the form.
        /// </value>
        public abstract Type FormType { get; }

        /// <summary>
        /// Determines whether the specified group is supported.
        /// </summary>
        /// <param name="group">The group.</param>
        /// <param name="entity">The entity.</param>
        /// <returns>
        ///   <c>true</c> if the specified group is supported; otherwise, <c>false</c>.
        /// </returns>
        public abstract bool IsSupported(string group, object entity);

        /// <summary>
        /// Shows this instance.
        /// </summary>
        /// <param name="entities">The entities.</param>
        public void Show(IEnumerable entities, Rectangle bounds)
        {
            Contract.Requires(entities != null);

            if (_form != null)
                return;

            _form = (Form)Activator.CreateInstance(FormType);

            // Map values from the board to the form
            BoardToForm(entities, _form);

            _form.StartPosition = FormStartPosition.Manual;
            _form.SetBounds(bounds.Left, bounds.Top, bounds.Width, bounds.Height, BoundsSpecified.All);
            _form.Show();
        }

        /// <summary>
        /// Closes this instance.
        /// </summary>
        public void Close()
        {
            if (_form == null)
                return;

            _form.Close();
            _form = null;
        }

        /// <summary>
        /// Maps the values.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <param name="form">The form.</param>
        private void BoardToForm(IEnumerable entities, Form form)
        {
        }
    }
}
