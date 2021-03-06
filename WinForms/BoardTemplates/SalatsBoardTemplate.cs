﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CanteenBoard.Entities.Boards;
using CanteenBoard.WinForms.Forms.Boards;
using CanteenBoard.Entities.Menu;
using System.Diagnostics.Contracts;
using System.Collections;
using System.Windows.Forms;
using System.Drawing;

namespace CanteenBoard.WinForms.BoardTemplates
{
    /// <summary>
    /// Daily menu board template.
    /// </summary>
    public class SalatsBoardTemplate : BoardTemplate
    {
        private static readonly Color DefaultSoupsBackColor = Color.Purple;
        private static readonly Color DefaultSalatsBackColor = Color.FromArgb(128, 255, 128);
        private static readonly Color DefaultFreeBackColor = Color.FromArgb(0, 0, 0);

        public const string SoupsGroup = "Soups";
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
            get { return new[] { SoupsGroup, SalatsGroup }; }
        }

        /// <summary>
        /// Gets the default colors.
        /// </summary>
        /// <value>
        /// The default colors.
        /// </value>
        protected override Color[] DefaultBackColors
        {
            get { return new Color[] { DefaultSoupsBackColor, DefaultSalatsBackColor, DefaultFreeBackColor }; }
        }

        protected override Form CreateForm()
        {
            SlotsBoardForm result = new SlotsBoardForm();

            SlotGroup soupsSlotGroup = new SlotGroup(result.Slots, SoupsGroup, BackColors[SoupsGroup], 0, 3);
            SlotGroup salatsBackColor = new SlotGroup(result.Slots, SalatsGroup, BackColors[SalatsGroup]);
            SlotGroup freeTextSlotGroup = new SlotGroup(result.Slots, FreeTextGroup, BackColors[FreeTextGroup], 9, 1, 1);

            result.SlotGroups = SlotGroup.Chain(soupsSlotGroup, salatsBackColor, freeTextSlotGroup);

            return result;
        }

        /// <summary>
        /// Maps the values.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <param name="form">The form.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        protected override void BoardToForm(object[] entities, Form form)
        {
            SlotsBoardForm slotsBoardForm = (SlotsBoardForm)form;
            for (int i = 0; i < Groups.Length; i++)
                slotsBoardForm.SlotGroups[i].BackColor = BackColors[Groups[i]];
            slotsBoardForm.SlotGroups[slotsBoardForm.SlotGroups.Length - 1].BackColor = BackColors[FreeTextGroup];
            slotsBoardForm.SetData(entities);
        }
    }
}
