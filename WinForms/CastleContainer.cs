using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.Windsor;

namespace CanteenBoard.WinForms
{
    /// <summary>
    /// Windsor Castle container.
    /// </summary>
    internal static class CastleContainer
    {
        /// <summary>
        /// The container.
        /// </summary>
        private static WindsorContainer container;

        /// <summary>
        /// Gets or sets the instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static WindsorContainer Instance
        {
            get
            {
                if (container == null)
                {
                    container = new WindsorContainer();
                }
                return container;
            }
        }

        /// <summary>
        /// Resolves this instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Resolve<T>()
        {
            return Instance.Resolve<T>();
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        public static void Dispose()
        {
            if (container != null)
                container.Dispose();

            container = null;
        }
    }
}
