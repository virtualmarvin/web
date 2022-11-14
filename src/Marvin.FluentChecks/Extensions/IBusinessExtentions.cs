using System.Linq.Expressions;
using Marvin.FluentChecks.Extensions;

namespace Marvin.FluentChecks.Extensions
{
    public static class IBusinessExtentions
    {
        public static IBusiness Check(this IBusiness business)
        {
            return business;
        }

        public static IBusiness IsDefault<T>(this IBusiness business, Expression<Func<T?>> expression)
        {
            var body = (MemberExpression)expression.Body;
            var func = expression.Compile();

            if (func() is null)
            {
                throw new ArgumentNullException(body.Member.Name);
            }

            var value = func();

            /*if(value.IsDefault())
            {
                return business;
            }*/


            return business;
        }
    }
}
