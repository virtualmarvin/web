using FuncSharp;
using Marvin.FluentChecks.Exceptions;
using System.Linq.Expressions;

namespace Marvin.FluentChecks.Extensions
{
    public static class ICheckExtentions
    {
        /// <summary>
        /// Contracts represent data that has been miscoded
        /// Also known as shit you did wrong
        /// </summary>
        /// <param name="check">The current <seealso cref="ICheck"/></param>
        /// <param name="func">A function that returns a <see cref="bool"/></param>
        /// <param name="ex">The exception to add if the function is true</param>
        /// <returns>The current <seealso cref="ICheck"/></returns>
        public static ICheck Contract(this ICheck check, Func<bool> func, Exception ex)
        {
            return check.ContractRule(func, ex);
        }

        /// <summary>
        /// Checks if the Argument is null
        /// </summary>
        /// <typeparam name="T">Value under test</typeparam>
        /// <param name="check">The current <see cref="ICheck"/></param>
        /// <param name="expression">The expression</param>
        /// <returns>The current <see cref="ICheck"/></returns>
        public static ICheck ArgNullContract<T>(this ICheck check, Expression<Func<T?>> expression)
        {
            var body = (MemberExpression)expression.Body;
            var func = expression.Compile();

            return check.ContractRule(() => func() is null, new ArgumentNullException(body.Member.Name));
        }

        /// <summary>
        /// Business logic reports an error, usually denoting errors entered by a user
        /// Also known as shit they did wrong
        /// </summary>
        /// <param name="check">The current <seealso cref="ICheck"/></param>
        /// <param name="func">A function that returns a <see cref="bool"/></param>
        /// <param name="error">The error to add if the function is true</param>
        /// <returns>The current <seealso cref="ICheck"/></returns>
        public static ICheck Business(this ICheck check, Func<bool> func, string error)
        {
            return check.BusinessRule(func, error);
        }

        /// <summary>
        /// Validate and throw any validation exceptions here
        /// </summary>
        /// <param name="check">The current <seealso cref="ICheck"/></param>
        /// <returns>The current <seealso cref="ICheck"/></returns>
        /// <exception cref="ValidationException">Thrown if any validation exceptions occur</exception>
        public static ICheck Validate(this ICheck check)
        {
            if (check.Exceptions.Any())
            {
                check.Exceptions.Count().Match(1,
                    t => throw new ValidationException(Values.VALIDATION_EXCEPTION_MESSAGE, check.Exceptions.First()),
                    f => throw new ValidationException(Values.VALIDATION_EXCEPTION_MESSAGE, new MultiException(check.Exceptions)));
            }

            return check;
        }
    }
}
