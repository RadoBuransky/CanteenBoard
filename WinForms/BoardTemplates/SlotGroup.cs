using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using CanteenBoard.WinForms.Forms.Boards;
using System.Drawing;
using System.Diagnostics.Contracts;
using CanteenBoard.Entities.Menu;

namespace CanteenBoard.WinForms.BoardTemplates
{
    public class SlotGroup
    {
        /// <summary>
        /// The board slots
        /// </summary>
        private readonly ReadOnlyCollection<BoardSlot> _boardSlots;

        /// <summary>
        /// Initializes a new instance of the <see cref="SlotGroup" /> class.
        /// </summary>
        /// <param name="boardSlots">The board slots.</param>
        /// <param name="foodGroup">The food group.</param>
        /// <param name="backColor">Color of the back.</param>
        /// <param name="startIndex">The start index.</param>
        /// <param name="maxCount">The max count.</param>
        /// <param name="minCount">The min count.</param>
        public SlotGroup(ReadOnlyCollection<BoardSlot> boardSlots, string foodGroup, Color backColor, int? startIndex = null, int? maxCount = null, int? minCount = 0)
        {
            _boardSlots = boardSlots;
            FoodGroup = foodGroup;
            BackColor = backColor;
            StartIndex = startIndex;
            MaxCount = maxCount;
            MinCount = minCount;
            LastUsedIndex = null;
        }

        /// <summary>
        /// Gets the food group.
        /// </summary>
        /// <value>
        /// The food group.
        /// </value>
        public string FoodGroup { get; private set; }

        /// <summary>
        /// Gets the color of the back.
        /// </summary>
        /// <value>
        /// The color of the back.
        /// </value>
        public Color BackColor { get; set; }

        /// <summary>
        /// Gets the start index.
        /// </summary>
        /// <value>
        /// The start index.
        /// </value>
        public int? StartIndex { get; private set; }

        /// <summary>
        /// Gets the max count.
        /// </summary>
        /// <value>
        /// The max count.
        /// </value>
        public int? MaxCount { get; private set; }

        /// <summary>
        /// Gets the min count.
        /// </summary>
        /// <value>
        /// The min count.
        /// </value>
        public int? MinCount { get; private set; }

        /// <summary>
        /// Gets the last index of the used.
        /// </summary>
        /// <value>
        /// The last index of the used.
        /// </value>
        public int? LastUsedIndex { get; private set; }

        /// <summary>
        /// Gets or sets the prev slot group.
        /// </summary>
        /// <value>
        /// The prev slot group.
        /// </value>
        public SlotGroup PrevSlotGroup { get; set; }

        /// <summary>
        /// Gets or sets the next slot group.
        /// </summary>
        /// <value>
        /// The next slot group.
        /// </value>
        public SlotGroup NextSlotGroup { get; set; }

        /// <summary>
        /// Chains the specified slot groups.
        /// </summary>
        /// <param name="slotGroups">The slot groups.</param>
        public static SlotGroup[] Chain(params SlotGroup[] slotGroups)
        {
            SlotGroup prev = null;
            foreach (SlotGroup slotGroup in slotGroups)
            {
                slotGroup.PrevSlotGroup = prev;
                if (prev != null)
                    prev.NextSlotGroup = slotGroup;

                prev = slotGroup;
            }

            return slotGroups;
        }

        /// <summary>
        /// Sets the data.
        /// </summary>
        /// <param name="entities">The entities.</param>
        public void SetData(object[] entities)
        {
            Contract.Requires(entities != null);

            // Reset
            LastUsedIndex = null;

            // Get starting index
            int index = GetStartingIndex();

            // Process all entities
            int counter = 0;
            for (int i = 0; i < entities.Length; i++)
            {
                // Check entity type, board and group assignment
                if (!IsOurEntity(entities[i]))
                    continue;

                // Check index value
                if (!IsIndexWithinGroup(index, counter, entities))
                    return;

                // Set data
                _boardSlots[index].SetData(entities[i]);

                // Set backround and move next
                PaintAndNext(ref index, ref counter);
            }

            if ((MaxCount == null) ||
                ((MinCount != null) && (counter < MinCount)))
            {
                // Color the rest
                while (IsIndexWithinGroup(index, counter, entities))
                {
                    _boardSlots[index].Clear();

                    // Set backround and move next
                    PaintAndNext(ref index, ref counter);
                }
            }
        }

        /// <summary>
        /// Paints the and next.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="counter">The counter.</param>
        private void PaintAndNext(ref int index, ref int counter)
        {
            _boardSlots[index].BackgroundColor = BackColor;

            LastUsedIndex = index;

            // Increment counters
            index++;
            counter++;
        }

        /// <summary>
        /// Determines whether [is index within range] [the specified index].
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>
        ///   <c>true</c> if [is index within range] [the specified index]; otherwise, <c>false</c>.
        /// </returns>
        private bool IsIndexWithinGroup(int index, int counter, object[] entities)
        {
            if (MaxCount != null)
                return counter < MaxCount.Value;

            if ((NextSlotGroup != null) &&
                (NextSlotGroup.StartIndex != null))
                return index < NextSlotGroup.StartIndex.Value;

            if ((NextSlotGroup == null) ||
                (NextSlotGroup.StartIndex == null))
                return index < _boardSlots.Count;

            return index < NextSlotGroup.StartIndex.Value;
        }

        /// <summary>
        /// Gets the index of the starting.
        /// </summary>
        /// <returns></returns>
        private int GetStartingIndex()
        {
            if (PrevSlotGroup == null)
                return StartIndex ?? 0;

            // Cool, isn't it?
            return (PrevSlotGroup.LastUsedIndex ?? -1) + 1;
        }

        /// <summary>
        /// Determines whether [is our entity] [the specified entity].
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>
        ///   <c>true</c> if [is our entity] [the specified entity]; otherwise, <c>false</c>.
        /// </returns>
        private bool IsOurEntity(object entity)
        {
            if (entity == null)
                return false;

            if (string.IsNullOrEmpty(FoodGroup))
                // If food group is not defined, this group is for free text
                return entity is string;

            Food food = entity as Food;
            if ((food == null) ||
                (food.BoardAssignment == null))
                return false;

            // Is this food ours?
            return food.BoardAssignment.Group == FoodGroup;
        }
    }
}
