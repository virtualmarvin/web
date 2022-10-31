using System.Diagnostics;
using System.Runtime.Serialization;

namespace Marvin.FluentChecks.Exceptions
{
    /// <summary>
    /// Thrown when a validation exception has occurred
    /// </summary>
    [DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
    [Serializable]
    public class ValidationException : Exception
    {
        /// <summary>
        /// Initialize a new instance of the <see cref="ValidationException"/> class
        /// </summary>
        public ValidationException()
        {
        }

        /// <summary>
        /// Initialize a new instance of the <see cref="ValidationException"/> 
        /// class with a specific error message
        /// </summary>
        public ValidationException(string? message) : base(message)
        {
        }

        /// <summary>
        /// Initialize a new instance of the <see cref="MultiException"/> 
        /// class with a specific error message and a reference to the inner
        /// exception that is the cause of this exception
        /// </summary>
        public ValidationException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        /// <inheritdoc />
        protected ValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        private string GetDebuggerDisplay()
        {
            return ToString();
        }
    }
}
