namespace Marvin.FluentChecks
{
    /// <summary>
    /// Contracts represent data that has been miscoded
    /// Also known as shit you did wrong
    /// </summary>
    public interface IContract
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
        int ExceptionCount { get; }

        /// <summary>
        /// Add an exception to the collection
        /// </summary>
        /// <param name="ex">The exception to add</param>
        /// <returns>The current Validation</returns>
        IContract AddException(Exception ex);

        /// <summary>
        /// Value set when validations have been checked
        /// </summary>
        bool Validated { get; }

        /// <summary>
        /// Updated the class to show that check has been called
        /// </summary>
        void Checked();
    }

    /// <inheritdoc />
    public sealed class Contract : IContract
    {
        private readonly List<Exception> _exceptions = new(1);

        private Contract() { }

        /// <inheritdoc />
        public IEnumerable<Exception> Exceptions => _exceptions;

        /// <inheritdoc />
        public bool HasExceptions => ExceptionCount > 0;
        
        /// <inheritdoc />
        public int ExceptionCount => _exceptions.Count;

        /// <inheritdoc />
        public IContract AddException(Exception ex)
        {
            lock (_exceptions)
            {
                _exceptions.Add(ex);
            }

            return this;
        }

        /// <inheritdoc />
        public bool Validated { get; private set; }
        
        /// <inheritdoc />
        public void Checked()
        {
            Validated = true;
        }

        /// <summary>
        /// Start the validation process with a null <see cref="Validation"/> class
        /// </summary>
        /// <returns>null</returns>
        public static IContract Begin() => new Contract();
    }
}
