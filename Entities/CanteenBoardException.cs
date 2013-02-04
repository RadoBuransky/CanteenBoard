using System;

namespace CanteenBoard.Entities
{
    /// <summary>
    /// Base exception
    /// </summary>
    public class CanteenBoardException : ApplicationException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CanteenBoardException" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public CanteenBoardException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CanteenBoardException" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public CanteenBoardException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
