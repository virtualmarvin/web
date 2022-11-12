using FuncSharp;
using Marvin.FluentChecks.Exceptions;
using System.Linq.Expressions;

namespace Marvin.FluentChecks.Extensions
{
    public static class IBusinessExtentions
    {

        public static bool Check(this IBusiness business)
        {
            return true;
        }
    }
}
