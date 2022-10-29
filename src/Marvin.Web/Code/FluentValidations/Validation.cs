namespace Marvin.Web.Code.FluentValidations
{
    /// <summary>
    /// A collection of Validation exceptions
    /// </summary>
    public sealed class Validation
    {
        private readonly List<Exception> _exceptions = new(1);

        /// <summary>
        /// A collection of Validation related Exceptions
        /// </summary>
        public IEnumerable<Exception> Exceptions => _exceptions;

        public bool Validated { get; } = false;

        /// <summary>
        /// Add an exception to the collection
        /// </summary>
        /// <param name="ex">The exception to add</param>
        /// <returns>The current Validation</returns>
        public Validation AddException(Exception ex)
        {
            lock (_exceptions)
            {
                _exceptions.Add(ex);
            }

            return this;
        }
    }

}
