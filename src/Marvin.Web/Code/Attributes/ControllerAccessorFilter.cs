using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Marvin.Web
{
    // Gets controller reference to actionmodel

    public class ControllerAccessorFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (context.Controller is Controller controller)
                context.HttpContext.Features.Set<Controller>(controller);

            await next();
        }
    }
}