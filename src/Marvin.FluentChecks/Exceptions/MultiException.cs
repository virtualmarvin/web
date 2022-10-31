using Marvin.FluentChecks.Extensions;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace Marvin.FluentChecks.Exceptions
{
    /// <summary>
    /// Represents a collection of errors that occur during application execution
    /// </summary>
    [DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
    [Serializable]
    public class MultiException : Exception
    {
        private const string MESSAGE = "There is at least one validation exception";
        private readonly Exception[] _innerExceptions;

        /// <summary>
        /// Initialize a new instance of the <see cref="MultiException"/> class
        /// </summary>
        public MultiException()
        {
            _innerExceptions = Array.Empty<Exception>();
        }

        /// <summary>
        /// Initialize a new instance of the <see cref="MultiException"/> 
        /// class with a specific error message
        /// </summary>
        public MultiException(string? message) : base(message)
        {
            _innerExceptions = Array.Empty<Exception>();
        }

        /// <summary>
        /// Initialize a new instance of the <see cref="MultiException"/> 
        /// class with a specific error message and a reference to the inner
        /// exception that is the cause of this exception
        /// </summary>
        public MultiException(string? message, Exception? innerException) : base(message, innerException)
        {
            if (innerException.IsNotNull())
            {
                _innerExceptions = new Exception[1] { innerException };
            }
            else 
            {
                _innerExceptions = Array.Empty<Exception>();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultiException"/> class
        /// with serialized data
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="SerializationException" />
        protected MultiException(SerializationInfo info, StreamingContext context) 
            : base(info, context)
        {
            _innerExceptions = Array.Empty<Exception>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultiException"/> class
        /// with a reference to the inner
        /// exceptions that are the cause of this exception
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        public MultiException(IEnumerable<Exception> innerExceptions)
            : this(MESSAGE, innerExceptions)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultiException"/> class
        /// with a reference to the inner
        /// exceptions that are the cause of this exception
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        public MultiException(Exception[] innerExceptions)
            : this(MESSAGE, (IEnumerable<Exception>)innerExceptions)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultiException"/> class
        /// with a specific error message and a reference to the inner
        /// exceptions that are the cause of this exception
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        public MultiException(string? message, Exception[] innerExceptions)
            : this(message, (IEnumerable<Exception>)innerExceptions)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultiException"/> class
        /// with a specific error message and a reference to the inner
        /// exceptions that are the cause of this exception
        /// </summary>
        /// <exception cref="ArgumentNullException" />
        public MultiException(string? message, IEnumerable<Exception> innerExceptions)
            : base(message, innerExceptions.FirstOrDefault())
        {
            _innerExceptions = innerExceptions.ToArray();
        }

        /// <summary>
        /// a reference to the inner
        /// exceptions that are the cause of this exception
        /// </summary>
        public IEnumerable<Exception> InnerExceptions
        {
            get
            {
                for (int i = 0; i < _innerExceptions.Length; ++i)
                {
                    yield return _innerExceptions[i];
                }
            }
        }

        private string GetDebuggerDisplay()
        {
            return ToString();
        }
    }
}
