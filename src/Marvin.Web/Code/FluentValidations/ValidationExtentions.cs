namespace Marvin.Web.Code.FluentValidations
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
        public static Validation ArgumentNullCheck<T>(this Validation validation, T theObject, string paramName)
            where T : class
        {
            if (theObject == null)
                return (validation ?? new Validation()).AddException(new ArgumentNullException(paramName));
            else
                return validation;
        }

        public static Validation? Check(this Validation validation)
        {
            if (validation == null)
                return validation;
            else
            {
                if (validation.Exceptions.Take(2).Count() == 1)
                    throw new ValidationException(message, validation.Exceptions.First()); // ValidationException is just a standard Exception-derived class with the usual four constructors
                else
                    throw new ValidationException(message, new MultiException(validation.Exceptions)); // implementation shown below
            }
        }
    }
}
}
