using System.Runtime.Serialization;

namespace Marvin.Web.Code.Exceptions
{
    /// <summary>
    /// Thrown when a validation exception has occurred
    /// </summary>
    public class ValidationException : Exception
    {
        /// <inheritdoc />
        public ValidationException()
        {
        }

        /// <inheritdoc />
        public ValidationException(string? message) : base(message)
        {
        }

        /// <inheritdoc />
        public ValidationException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        /// <inheritdoc />
        protected ValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
