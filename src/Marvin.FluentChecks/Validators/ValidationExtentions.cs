using Marvin.FluentChecks.Exceptions;
using Marvin.FluentChecks.Extensions;
using System.Diagnostics.CodeAnalysis;

namespace Marvin.FluentChecks.Validators
{
    /// <summary>
    /// Extensions for validating conditions
    /// </summary>
    public static class ValidationExtensions
    {

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
        {
            if (theObject.IsNull())
            {
                return validation.AddException(new ArgumentNullException(paramName));
            }
            else
            {
                return validation;
            }
        }

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
                throw new ValidationException(Values.VALIDATION_EXCEPTION_MESSAGE, validation.Exceptions.First());
            }
            else
            {
                throw new ValidationException(Values.VALIDATION_EXCEPTION_MESSAGE, new MultiException(validation.Exceptions));
            }
        }
    }
}
