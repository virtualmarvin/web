using Marvin.Web.Code.Exceptions;

namespace Marvin.Web.Code.FluentValidations
{
    /// <summary>
    /// A collection of Validation exceptions
    /// </summary>
    public interface IValidation
    {
        /// <summary>
        /// A collection of Validation related Exceptions
        /// </summary>
        IEnumerable<Exception> Exceptions { get; }

        /// <summary>
        /// Value denoting that there are exceptions in the class
        /// </summary>
        bool HasExceptions { get; }

        /// <summary>
        /// Value set when validations have been checked
        /// </summary>
        bool Validated { get; }

        /// <summary>
        /// Add an exception to the collection
        /// </summary>
        /// <param name="ex">The exception to add</param>
        /// <returns>The current Validation</returns>
        Validation AddException(Exception ex);
    }

    /// <inheritdoc />
    public sealed class Validation : IValidation
    {
        private readonly List<Exception> _exceptions = new(1);
        
        private Validation()
        { }

        /// <inheritdoc />
        public IEnumerable<Exception> Exceptions => _exceptions;

        /// <inheritdoc />
        public bool Validated { get; } = false;
        
        /// <inheritdoc />
        public bool HasExceptions => _exceptions.Count > 0;

        /// <inheritdoc />
        public Validation AddException(Exception ex)
        {
            lock (_exceptions)
            {
                _exceptions.Add(ex);
            }

            return this;
        }

        /// <summary>
        /// Start the validation process with a null <see cref="Validation"/> class
        /// </summary>
        /// <returns>null</returns>
        public static IValidation Validate() => new Validation();

        /// <summary>
        /// While in Debug validate that the class has been Validated
        /// </summary>
        ~Validation()
        {
            if (!Validated)
            {
#pragma warning disable S1048 // Destructors should not throw exceptions
#if DEBUG 
                throw new ValidationException("");
#endif
#pragma warning restore S1048 // Destructors should not throw exceptions
            }
        }
    }
}
