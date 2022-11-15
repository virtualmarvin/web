using FuncSharp;
using Marvin.FluentChecks.Extensions;
using Marvin.Web.Code.Exceptions;
using System.Diagnostics.CodeAnalysis;

namespace Marvin.Web.Code.Validators
{
    /// <summary>
    /// Extensions for validating conditions
    /// </summary>
    public static class ValidationExtensions
    {
        private const string MESSAGE = "At least one validation exception has occurred, see inner exception for details";

        /// <summary>
        /// Check if a parameter is null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="validation"><see cref="Validation"/></param>
        /// <param name="theObject">the object to validate</param>
        /// <param name="paramName">Name of the parameter</param>
        /// <returns><see cref="Validation"/></returns>
        public static IValidation ArgumentNullCheck<T>(this IValidation validation, [NotNullWhen(returnValue: false)] T? theObject, string paramName)
            where T : class 
            => theObject.IsNull().Match(
                t => validation.AddException(new ArgumentNullException(paramName)),
                f => validation);

        /// <summary>
        /// Check and throw any validation exceptions here
        /// </summary>
        /// <param name="validation"><see cref="Validation"/></param>
        /// <returns><see cref="Validation"/></returns>
        /// <exception cref="ValidationException">If <see cref="Validation"/> contains any exceptions then they all get thrown here</exception>
        public static bool Check(this IValidation validation)
        {
            validation.Checked();

            if (!validation.HasExceptions)
            {
                return true;
            }

            if (validation.ErrorCount == 1)
            {
                throw new ValidationException(MESSAGE, validation.Exceptions.First());
            }
            else
            {
                throw new ValidationException(MESSAGE, new MultiException(validation.Exceptions));
            }
        }
    }
}
