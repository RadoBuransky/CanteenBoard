using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CanteenBoard.Entities.Boards;
using System.Diagnostics.Contracts;
using CanteenBoard.Entities;
using CanteenBoard.Core.Common;
using CanteenBoard.Repositories;

namespace CanteenBoard.Core.Processors
{
    public class BoardProcessor : CommonProcessor<Board>, IBoardProcessor
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BoardProcessor" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public BoardProcessor(IRepository repository)
            : base(repository)
        {
        }

        /// <summary>
        /// Adds the specified board.
        /// </summary>
        /// <param name="board">The board.</param>
        /// <param name="group">The group.</param>
        /// <param name="entity">The entity.</param>
        public void Add(Board board, string group, object entity)
        {
            Contract.Requires(board != null);
            Contract.Requires(!string.IsNullOrEmpty(group));
            Contract.Requires(entity != null);

            if (!board.BoardTemplate.IsSupported(group, entity))
            {
                throw new CanteenBoardException(string.Format("{0} entity is not supported for the {1} group!", entity.GetType().Name, group));
            }

            List<object> entities = board.GroupData[group];
            if (entities == null)
            {
                entities = new List<object>();
                board.GroupData[group] = entities;
            }

            entities.Add(entity);
        }

        public void Remove(Board board, string group, object entity)
        {
            Contract.Requires(board != null);
            Contract.Requires(!string.IsNullOrEmpty(group));
            Contract.Requires(entity != null);

            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the specified screen device name.
        /// </summary>
        /// <param name="screenDeviceName">Name of the screen device.</param>
        /// <returns></returns>
        public Board Get(string screenDeviceName)
        {
            Contract.Requires(!string.IsNullOrEmpty(screenDeviceName));

            var boards = from board in Repository.Find<Board>()
                         where board.ScreenDeviceName == screenDeviceName
                         select board;

            return boards.FirstOrDefault();
        }
    }
}
