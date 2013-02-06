﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics.Contracts;

namespace CanteenBoard.Entities.Boards
{
    /// <summary>
    /// Logical screen.
    /// </summary>
    public abstract class BoardTemplate
    {
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
        /// <param name="board">The board.</param>
        public void Show(Board board)
        {
            Contract.Requires(board != null);

            Form form = (Form)Activator.CreateInstance(FormType);

            // Map values from the board to the form
            BoardToForm(board, form);
            
            form.Show();
        }

        /// <summary>
        /// Maps the values.
        /// </summary>
        /// <param name="board">The board.</param>
        /// <param name="form">The form.</param>
        private void BoardToForm(Board board, Form form)
        {
        }
    }
}
