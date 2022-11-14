using FuncSharp;
using Marvin.FluentChecks.Exceptions;
using System.Linq.Expressions;

namespace Marvin.FluentChecks.Extensions
{
    public static class IContractExtentions
    {

        /// <summary>
        /// Checks if the Argument is null
        /// </summary>
        /// <typeparam name="T">Value under test</typeparam>
        /// <param name="contract">The current <see cref="IContract"/></param>
        /// <param name="expression">The expression</param>
        /// <returns>The current <see cref="IContract"/></returns>
        public static IContract ArgNull<T>(this IContract contract, Expression<Func<T?>> expression)
        {
            var body = (MemberExpression)expression.Body;
            var func = expression.Compile();

            if (func() is null)
            {
                contract.AddException(new ArgumentNullException(body.Member.Name));
            }

            return contract;
        }

        /// <summary>
        /// Check and throw any validation exceptions here
        /// </summary>
        /// <param name="validation"><see cref="Validation"/></param>
        /// <returns><see cref="Validation"/></returns>
        /// <exception cref="ValidationException">If <see cref="Validation"/> contains any exceptions then they all get thrown here</exception>
        public static IContract Check(this IContract contract)
        {
            contract.Checked();

            if (!contract.HasExceptions)
            {
                return contract;
            }

            contract.ExceptionCount.Match(1,
                t => throw new ValidationException(Values.VALIDATION_EXCEPTION_MESSAGE, contract.Exceptions.First()),
                f => throw new ValidationException(Values.VALIDATION_EXCEPTION_MESSAGE, new MultiException(contract.Exceptions)));

            // This is unreachable, but the compiler doesn't know it.
            return contract;
        }
    }
}
