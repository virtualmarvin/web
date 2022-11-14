namespace Marvin.FluentChecks
{
    /// <summary>
    /// Business logic reports an error, usually denoting errors entered by a user
    /// Also known as shit they did wrong
    /// </summary>
    public interface IBusiness
    {
        /// <summary>
        /// Returns true if there are errors
        /// </summary>
        bool HasErrors { get; }

        /// <summary>
        /// returns true if there are no errors
        /// </summary>
        bool Success { get; }
    }

    /// <inheritdoc />
    public sealed class Business : IBusiness
    {
        private Business() { }

        /// <inheritdoc />
        public bool Success => true;

        /// <inheritdoc />
        public bool HasErrors { get; }

        /// <summary>
        /// Start validating business logic
        /// </summary>
        /// <returns>An instance that implements <seealso cref="IBusiness"/></returns>
        public static IBusiness Begin() => new Business();
    }
}
