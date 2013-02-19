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
    public class BoardProcessor : CommonProcessor<ScreenTemplate>, IBoardProcessor
    {
        /// <summary>
        /// The board templates
        /// </summary>
        private IEnumerable<BoardTemplate> _boardTemplates;

        /// <summary>
        /// Initializes a new instance of the <see cref="BoardProcessor" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="boardTemplates">The board templates.</param>
        public BoardProcessor(IRepository repository, IEnumerable<BoardTemplate> boardTemplates)
            : base(repository)
        {
            Contract.Requires(boardTemplates != null);

            _boardTemplates = boardTemplates;
        }

        /// <summary>
        /// Gets the screen template.
        /// </summary>
        /// <param name="screenDeviceName">Name of the screen device.</param>
        /// <returns></returns>
        public ScreenTemplate GetScreenTemplate(string screenDeviceName)
        {
            Contract.Requires(!string.IsNullOrEmpty(screenDeviceName));

            var boards = from board in Repository.Find<ScreenTemplate>()
                         where board.ScreenDeviceName == screenDeviceName
                         select board;

            return boards.FirstOrDefault();
        }

        /// <summary>
        /// Saves the screen template.
        /// </summary>
        /// <param name="screenTemplate">The screen template.</param>
        public void SaveScreenTemplate(ScreenTemplate screenTemplate)
        {
            Contract.Requires(screenTemplate != null);
            Contract.Requires(!string.IsNullOrEmpty(screenTemplate.ScreenDeviceName));

            Repository.Save(screenTemplate);
        }

        /// <summary>
        /// Gets the board template.
        /// </summary>
        /// <param name="boardTemplateName">Name of the board template.</param>
        /// <returns></returns>
        public BoardTemplate GetBoardTemplate(string boardTemplateName)
        {
            Contract.Requires(!string.IsNullOrEmpty(boardTemplateName));

            foreach (BoardTemplate boardTemplate in _boardTemplates)
            {
                if (boardTemplate.Name == boardTemplateName)
                {
                    return boardTemplate;
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the board templates.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BoardTemplate> GetBoardTemplates()
        {
            return _boardTemplates;
        }
    }
}
