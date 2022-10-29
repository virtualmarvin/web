namespace Marvin.Web.Code.FluentValidations
{
    /// <summary>
    /// Used to start a fluent Validation process
    /// </summary>
    public static class Validate
    {
        /// <summary>
        /// Start the validation process with a null <see cref="Validation"/> class
        /// </summary>
        /// <returns>null</returns>
        public static Validation? Begin()
        {
            return default;
        }
    }
}
