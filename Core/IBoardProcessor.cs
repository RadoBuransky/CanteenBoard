using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CanteenBoard.Entities.Boards;

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
    }
}
