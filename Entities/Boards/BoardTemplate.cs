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
        /// Gets the form.
        /// </summary>
        /// <value>
        /// The form.
        /// </value>
        protected List<Form> Forms { get; private set; }

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
        /// Initializes a new instance of the <see cref="BoardTemplate" /> class.
        /// </summary>
        protected BoardTemplate()
        {
            Forms = new List<Form>();
        }

        /// <summary>
        /// Shows this instance.
        /// </summary>
        /// <param name="entities">The entities.</param>
        public Form Show(IEnumerable entities, Rectangle bounds)
        {
            Contract.Requires(entities != null);

            Form result = (Form)Activator.CreateInstance(FormType);

            // Map values from the board to the form
            BoardToForm(entities, result);

            result.StartPosition = FormStartPosition.Manual;
            result.SetBounds(bounds.Left, bounds.Top, bounds.Width, bounds.Height, BoundsSpecified.All);
            result.Show();

            Forms.Add(result);

            return result;
        }

        /// <summary>
        /// Closes this instance.
        /// </summary>
        public void CloseAll()
        {
            Forms.ForEach(form =>
                {
                    form.Close();
                    form = null;
                });
            Forms.Clear();
        }

        /// <summary>
        /// Refreshes all.
        /// </summary>
        /// <param name="entities">The entities.</param>
        public void RefreshAll(IEnumerable entities)
        {
            Forms.ForEach(form => BoardToForm(entities, form));
        }

        /// <summary>
        /// Maps the values.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <param name="form">The form.</param>
        protected abstract void BoardToForm(IEnumerable entities, Form form);
    }
}
