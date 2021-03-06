﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CanteenBoard.Entities.Boards;
using System.Windows.Forms;
using System.Drawing;

namespace CanteenBoard.Core
{
    public interface IBoardProcessor
    {
        /// <summary>
        /// Gets the screen template.
        /// </summary>
        /// <param name="screenDeviceName">Name of the screen device.</param>
        /// <returns></returns>
        ScreenTemplate GetScreenTemplate(string screenDeviceName);

        /// <summary>
        /// Saves the screen template.
        /// </summary>
        /// <param name="board">The board.</param>
        void SaveScreenTemplate(ScreenTemplate board);

        /// <summary>
        /// Gets the board template.
        /// </summary>
        /// <param name="boardTemplateName">Name of the board template.</param>
        /// <returns></returns>
        BoardTemplate GetBoardTemplate(string boardTemplateName);

        /// <summary>
        /// Gets the board templates.
        /// </summary>
        /// <returns></returns>
        IEnumerable<BoardTemplate> GetBoardTemplates();

        /// <summary>
        /// Gets all screen device names.
        /// </summary>
        /// <returns></returns>
        IEnumerable<string> GetAllScreenDeviceNames();

        /// <summary>
        /// Shows all boards.
        /// </summary>
        void ShowAllBoards();

        /// <summary>
        /// Refreshes all boards.
        /// </summary>
        void RefreshAllBoards();

        /// <summary>
        /// Sets the color of the custom.
        /// </summary>
        /// <param name="boardTemplateName">Name of the board template.</param>
        /// <param name="group">The group.</param>
        /// <param name="color">The color.</param>
        void SetCustomColor(string boardTemplateName, string group, Color color);

        /// <summary>
        /// Gets the color of the custom.
        /// </summary>
        /// <param name="boardTemplateName">Name of the board template.</param>
        /// <param name="group">The group.</param>
        /// <returns></returns>
        Color GetCustomColor(string boardTemplateName, string group);

        /// <summary>
        /// Gets the free text.
        /// </summary>
        /// <param name="boardTemplateName">Name of the board template.</param>
        /// <returns></returns>
        string GetFreeText(string boardTemplateName);

        /// <summary>
        /// Sets the free text.
        /// </summary>
        /// <param name="boardTemplateName">Name of the board template.</param>
        /// <param name="text">The text.</param>
        void SetFreeText(string boardTemplateName, string text);
    }
}
