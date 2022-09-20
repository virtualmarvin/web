using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Marvin.Web
{
    public class AdminMenuAttribute : ActionFilterAttribute
    {
        private readonly string _adminMenu;

        public AdminMenuAttribute(string adminMenu)
        {
            _adminMenu = adminMenu;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.Controller is Controller controller)
                controller.ViewBag.AdminMenu = _adminMenu;

            base.OnActionExecuting(filterContext);
        }
    }
}
