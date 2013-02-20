using System.Linq;
using System.Windows.Forms;
using System.Linq.Expressions;
using System.Collections.Generic;
using System;

namespace CanteenBoard.WinForms.Extensions
{
    public static class ComboBoxExtensions
    {
        /// <summary>
        /// Adds the KVP.
        /// </summary>
        /// <typeparam name="Key">The type of the ey.</typeparam>
        /// <typeparam name="Value">The type of the alue.</typeparam>
        /// <param name="comboBox">The combo box.</param>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public static int AddKVP<Key, Value>(this ComboBox comboBox, Key key, Value value)
        {
            return comboBox.Items.Add(new KeyValuePair<Key, Value>(key, value));
        }

        /// <summary>
        /// Selects the specified combo box.
        /// </summary>
        /// <typeparam name="Key">The type of the ey.</typeparam>
        /// <typeparam name="Value">The type of the alue.</typeparam>
        /// <param name="comboBox">The combo box.</param>
        /// <param name="predicate">The predicate.</param>
        public static void SelectKVP<Key, Value>(this ComboBox comboBox, Expression<Func<Value, bool>> predicate)
        {
            Func<Value, bool> func = predicate.Compile();

            foreach (KeyValuePair<Key, Value> item in comboBox.Items)
            {
                if ((item.Value != null) &&
                    (func(item.Value)))
                {
                    comboBox.SelectedItem = item;
                    break;
                }
            }
        }

        /// <summary>
        /// Selecteds the value KVP.
        /// </summary>
        /// <typeparam name="Key">The type of the ey.</typeparam>
        /// <typeparam name="Value">The type of the alue.</typeparam>
        /// <param name="comboBox">The combo box.</param>
        /// <returns></returns>
        public static Value SelectedValueKVP<Key, Value>(this ComboBox comboBox)
        {
            return ((KeyValuePair<Key, Value>)comboBox.SelectedItem).Value;
        }
    }
}
