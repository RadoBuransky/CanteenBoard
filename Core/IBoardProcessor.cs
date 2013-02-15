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
        /// Adds the specified entity to the group within the board.
        /// </summary>
        /// <param name="board">The board.</param>
        /// <param name="group">The group.</param>
        /// <param name="entity">The entity.</param>
        void Add(Board board, string group, object entity);

        /// <summary>
        /// Removes the specified entity.
        /// </summary>
        /// <param name="board">The board.</param>
        /// <param name="group">The group.</param>
        /// <param name="entity">The entity.</param>
        void Remove(Board board, string group, object entity);

        /// <summary>
        /// Gets the specified screen device name.
        /// </summary>
        /// <param name="screenDeviceName">Name of the screen device.</param>
        /// <returns></returns>
        Board Get(string screenDeviceName);
    }
}
