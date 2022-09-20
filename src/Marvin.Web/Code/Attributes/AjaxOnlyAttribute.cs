using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace Marvin.Web
{
    // Only accepts Ajax calls

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AjaxOnlyAttribute : ActionMethodSelectorAttribute
    {
        public override bool IsValidForRequest(RouteContext routeContext, ActionDescriptor action)
        {
            var headerValue =  routeContext.HttpContext.Request?.Headers["X-Requested-With"];
            return  headerValue.HasValue && headerValue.Value == "XMLHttpRequest";
        }
    }
}
