using AutoMapper;
using Marvin.Web.Areas._Related;
using Marvin.Web.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Marvin.Web
{
    // Base class to all ActionModels

    public class BaseModel
    {
        #region Dependency Injection

        protected static HttpContext HttpContext => ServiceLocator.Resolve<IHttpContextAccessor>().HttpContext!;

        // ** Lazy Injection Pattern

        private ICache cache = null!;
        private IExcel excel = null!;
        private IEmail email = null!;
        private IMapper mapper = null!;
        private IRollup rollup = null!;
        private UltraContext db = null!;
        private IRelated related = null!;
        private IWebHostEnvironment env = null!;
        private ICurrentUser currentUser = null!;
        private IViewedService viewedService = null!;
        private ILoggerFactory loggerFactory = null!;
        private IIdentityService identityService = null!;

        protected ICache _cache => cache ??= HttpContext.RequestServices.GetService<ICache>()!;
        protected IEmail _email => email ??= HttpContext.RequestServices.GetService<IEmail>()!;
        protected IExcel _excel => excel ??= HttpContext.RequestServices.GetService<IExcel>()!;
        protected IMapper _mapper => mapper ??= HttpContext.RequestServices.GetService<IMapper>()!;
        protected IRollup _rollup => rollup ??= HttpContext.RequestServices.GetService<IRollup>()!;
        protected UltraContext _db => db ??= HttpContext.RequestServices.GetService<UltraContext>()!;
        protected IRelated _related => related ??= HttpContext.RequestServices.GetService<IRelated>()!;
        protected IWebHostEnvironment _env => env ??= HttpContext.RequestServices.GetService<IWebHostEnvironment>()!;
        protected ICurrentUser _currentUser => currentUser ??= HttpContext.RequestServices.GetService<ICurrentUser>()!;
        protected IViewedService _viewedService => viewedService ??= HttpContext.RequestServices.GetService<IViewedService>()!;
        protected ILoggerFactory _loggerFactory => loggerFactory ??= HttpContext.RequestServices.GetService<ILoggerFactory>()!;
        protected IIdentityService _identityService => identityService ??= HttpContext.RequestServices.GetService<IIdentityService>()!;

        #endregion

        #region Controller

        private static Controller Controller { get => HttpContext.Features.Get<Controller>()!; }

        // Add additional controller methods and properties as needed.

        protected static RouteData RouteData { get => Controller.RouteData; }
        protected static HttpRequest Request { get => Controller.Request; }
        protected static HttpResponse Response { get => Controller.Response; }
        protected static ModelStateDictionary ModelState { get => Controller.ModelState; }

        protected virtual IActionResult View() => Controller.View();
        protected virtual IActionResult View(object model) => Controller.View(model);
        protected virtual IActionResult View(string viewName) => Controller.View(viewName);
        protected virtual IActionResult View(string viewName, object model) => Controller.View(viewName, model);

        protected virtual RedirectResult Redirect(string url) => Controller.Redirect(url);
        protected virtual RedirectResult RedirectPermanent(string url) => Controller.RedirectPermanent(url);
        protected virtual LocalRedirectResult LocalRedirect(string localUrl) => Controller.LocalRedirect(localUrl);
        protected virtual LocalRedirectResult LocalRedirectPermanent(string localUrl) => Controller.LocalRedirectPermanent(localUrl);

        protected virtual RedirectToActionResult RedirectToAction(string actionName) => Controller.RedirectToAction(actionName);
        protected virtual RedirectToActionResult RedirectToAction(string actionName, object routeValues) => Controller.RedirectToAction(actionName, routeValues);
        protected virtual RedirectToActionResult RedirectToAction(string actionName, string controllerName) => Controller.RedirectToAction(actionName, controllerName);
        protected virtual RedirectToActionResult RedirectToAction(string actionName, string controllerName, object routeValues) => Controller.RedirectToAction(actionName, controllerName, routeValues);

        protected virtual JsonResult Json(object data) => Controller.Json(data);
        protected virtual JsonResult Json(object data, object serializerSetting) => Controller.Json(data, serializerSetting);

        protected virtual FileContentResult File(byte[] fileContents, string contentType, string fileDownloadName) => Controller.File(fileContents, contentType, fileDownloadName);

        #endregion

        #region Handlers

        public virtual IActionResult Get() => View(this);
        public virtual IActionResult Post() => LocalRedirect(Referer);

        public virtual async Task<IActionResult> GetAsync() { await Task.Yield(); return View(this); }
        public virtual async Task<IActionResult> PostAsync() { await Task.Yield(); return LocalRedirect(Referer); }

        #endregion

        #region Referer

        public string Referer
        {
            get => HttpContext.PostedReferer() ??
                   HttpContext.Referer();
        }

        #endregion

        #region Alert

        public static string? Success { set => Controller.TempData["Success"] = value; get => Controller?.TempData["Success"]?.ToString(); }
        public static string? Failure { set => Controller.TempData["Failure"] = value; get => Controller?.TempData["Failure"]?.ToString(); }

        #endregion

        #region Meta

        public string? MetaTitle { set => Controller.ViewBag.Title = value; get => Controller?.ViewBag.Title; }
        public string? MetaKeywords { set => Controller.ViewBag.Keywords = value; get => Controller?.ViewBag.Keywords; }
        public string? MetaDescription { set => Controller.ViewBag.Description = value; get => Controller?.ViewBag.Description; }

        #endregion
    }
}
