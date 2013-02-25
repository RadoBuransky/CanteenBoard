using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CanteenBoard.Entities.Boards;
using CanteenBoard.WinForms.Forms.Boards;
using CanteenBoard.Entities.Menu;
using System.Diagnostics.Contracts;
using System.Collections;
using System.Windows.Forms;

namespace CanteenBoard.WinForms.BoardTemplates
{
    /// <summary>
    /// Daily menu board template.
    /// </summary>
    public class SalatsBoardTemplate : BoardTemplate
    {
        /// <summary>
        /// The soup group
        /// </summary>
        public const string SalatsGroup = "Salats";

        /// <summary>
        /// Gets the groups.
        /// </summary>
        /// <value>
        /// The groups.
        /// </value>
        /// <exception cref="System.NotImplementedException"></exception>
        public override string[] Groups
        {
            get { return new[] { SalatsGroup }; }
        }

        /// <summary>
        /// Gets the type of the form.
        /// </summary>
        /// <value>
        /// The type of the form.
        /// </value>
        public override Type FormType
        {
            get
            {
                return typeof(SalatsBoardForm);
            }
        }

        /// <summary>
        /// Determines whether the specified group is supported.
        /// </summary>
        /// <param name="group">The group.</param>
        /// <param name="entity">The entity.</param>
        /// <returns>
        ///   <c>true</c> if the specified group is supported; otherwise, <c>false</c>.
        /// </returns>
        public override bool IsSupported(string group, object entity)
        {
            Contract.Requires(!string.IsNullOrEmpty(group));
            Contract.Requires(entity != null);

            if (group == SalatsGroup)
            {
                return typeof(Food).IsAssignableFrom(entity.GetType());
            }

            return false;
        }

        /// <summary>
        /// Maps the values.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <param name="form">The form.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        protected override void BoardToForm(IEnumerable entities, Form form)
        {
            ((SalatsBoardForm)form).BoardToForm(entities);
        }
    }
}
