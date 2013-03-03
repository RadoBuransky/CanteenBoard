using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CanteenBoard.Entities.Boards;
using System.Diagnostics.Contracts;
using CanteenBoard.Entities;
using CanteenBoard.Core.Common;
using CanteenBoard.Repositories;
using System.Windows.Forms;
using CanteenBoard.Entities.Menu;
using System.Drawing;

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

        /// <summary>
        /// Gets all screen device names.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetAllScreenDeviceNames()
        {
            // Check all screens
            foreach (Screen screen in Screen.AllScreens)
            {
                if (screen.Primary)
                    continue;

                yield return GetCorrectedDeviceName(screen);
            }
        }

        /// <summary>
        /// Shows all boards.
        /// </summary>
        public void ShowAllBoards()
        {
            // Close all
            foreach (BoardTemplate boardTemplate in _boardTemplates)
                boardTemplate.CloseAll();

            // Check all screens
            foreach (string screenDeviceName in GetAllScreenDeviceNames())
            {
                // Get screen template for this screen
                ScreenTemplate screenTemplate = GetScreenTemplate(screenDeviceName);
                if ((screenTemplate == null) ||
                    (string.IsNullOrEmpty(screenTemplate.BoardTemplateName)))
                    continue;

                // Ger board template
                BoardTemplate boardTemplate = GetBoardTemplate(screenTemplate.BoardTemplateName);
                if (boardTemplate == null)
                    continue;

                foreach (string group in boardTemplate.Groups)
                {
                    boardTemplate.BackColors[group] = GetCustomColor(boardTemplate.Name, group);
                }
                boardTemplate.BackColors[BoardTemplate.FreeTextGroup] = GetCustomColor(boardTemplate.Name, BoardTemplate.FreeTextGroup);

                // Show board with live data
                boardTemplate.Show(GetLiveFood(boardTemplate.Name), GetScreenBounds(screenDeviceName));
            }
        }

        /// <summary>
        /// Refreshes all boards.
        /// </summary>
        public void RefreshAllBoards()
        {
            foreach (BoardTemplate boardTemplate in _boardTemplates)
            {
                boardTemplate.RefreshAll(GetLiveFood(boardTemplate.Name));
            }
        }

        /// <summary>
        /// Sets the color of the custom.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="color">The color.</param>
        public void SetCustomColor(string boardTemplateName, string group, Color color)
        {
            Contract.Requires(!string.IsNullOrEmpty(boardTemplateName));
            Contract.Requires(!string.IsNullOrEmpty(group));

            CustomColor customColor = new CustomColor();
            customColor.Key = CustomColorKey(boardTemplateName, group);
            customColor.SetColor(color);
            Repository.Save(customColor);

            BoardTemplate boardTemplate = GetBoardTemplate(boardTemplateName);
            boardTemplate.BackColors[group] = color;

            RefreshAllBoards();
        }

        /// <summary>
        /// Gets the color of the custom.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public Color GetCustomColor(string boardTemplateName, string group)
        {
            Contract.Requires(!string.IsNullOrEmpty(boardTemplateName));
            Contract.Requires(!string.IsNullOrEmpty(group));

            string key = boardTemplateName + group;
            CustomColor result = Repository.Find<CustomColor>().Where(cc => cc.Key == key).FirstOrDefault();
            if (result == null)
                return Color.Empty;

            return result;
        }

        /// <summary>
        /// Gets the free text.
        /// </summary>
        /// <param name="boardTemplateName">Name of the board template.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public string GetFreeText(string boardTemplateName)
        {
            Food food = FindFreeText(boardTemplateName);
            if (food == null)
                return string.Empty;

            return food.Title;
        }

        /// <summary>
        /// Sets the free text.
        /// </summary>
        /// <param name="boardTemplateName">Name of the board template.</param>
        /// <param name="text">The text.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void SetFreeText(string boardTemplateName, string text)
        {
            Food food = FindFreeText(boardTemplateName);
            if (food != null)
                Repository.Delete<Food>(food.Title);

            food = new Food();
            food.Title = text;
            food.BoardAssignment = new BoardAssignment() { BoardTemplateName = boardTemplateName, Group = BoardTemplate.FreeTextGroup };
            food.Visible = true;
            Repository.Save(food);

            RefreshAllBoards();
        }

        /// <summary>
        /// Finds the free text.
        /// </summary>
        /// <param name="boardTemplateName">Name of the board template.</param>
        /// <returns></returns>
        private Food FindFreeText(string boardTemplateName)
        {
            return (from f in Repository.Find<Food>()
                    where f.BoardAssignment != null &&
                        f.BoardAssignment.BoardTemplateName == boardTemplateName &&
                        f.BoardAssignment.Group == BoardTemplate.FreeTextGroup
                    select f).FirstOrDefault();
        }

        /// <summary>
        /// Gets the live food.
        /// </summary>
        /// <param name="boardTemplateName">Name of the board template.</param>
        /// <returns></returns>
        private Food[] GetLiveFood(string boardTemplateName)
        {
            // Get live food
            var liveFood = from f in Repository.Find<Food>()
                           where f.Visible &&
                            f.BoardAssignment != null &&
                            f.BoardAssignment.BoardTemplateName == boardTemplateName
                           orderby f.Index
                           select f;

            return liveFood.ToArray();
        }

        /// <summary>
        /// Gets the name of the corrected device.
        /// </summary>
        /// <param name="screen">The screen.</param>
        /// <returns></returns>
        private static string GetCorrectedDeviceName(Screen screen)
        {
            Contract.Requires(screen != null);

            int i = screen.DeviceName.IndexOf('\0');
            if (i > 0)
            {
                return screen.DeviceName.Substring(0, i);
            }

            return screen.DeviceName;
        }

        /// <summary>
        /// Customs the color key.
        /// </summary>
        /// <param name="boardTemplateName">Name of the board template.</param>
        /// <param name="group">The group.</param>
        /// <returns></returns>
        private static string CustomColorKey(string boardTemplateName, string group)
        {
            return boardTemplateName + group;
        }

        /// <summary>
        /// Gets the screen bounds.
        /// </summary>
        /// <param name="screenDeviceName">Name of the screen device.</param>
        /// <returns></returns>
        /// <exception cref="CanteenBoardException">Screen not found! [ + screenDeviceName + ]</exception>
        private Rectangle GetScreenBounds(string screenDeviceName)
        {
            foreach (Screen screen in Screen.AllScreens)
            {
                if (GetCorrectedDeviceName(screen) == screenDeviceName)
                {
                    return screen.Bounds;
                }
            }

            throw new CanteenBoardException("Screen not found! [" + screenDeviceName + "]");
        }
    }
}
