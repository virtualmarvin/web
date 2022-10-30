namespace Marvin.Web.Code.Validators
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
        /// The number of exceptions in the class
        /// </summary>
        int ErrorCount { get; }

        /// <summary>
        /// Value set when validations have been checked
        /// </summary>
        bool Validated { get; }

        /// <summary>
        /// Updated the class to show that check has been called
        /// </summary>
        void Checked();

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
        public int ErrorCount => _exceptions.Count;

        /// <inheritdoc />
        public bool Validated { get; private set; } = false;
        
        /// <inheritdoc />
        public bool HasExceptions => _exceptions.Count > 0;

        /// <inheritdoc />
        public void Checked()
        {
            Validated = true;
        }

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
        public static IValidation Begin() => new Validation();
    }
}
