using AutoMapper;
using Marvin.Web.Domain;

namespace Marvin.Web
{
    public abstract class BaseProfile : Profile
    {
        // Base class to all Profiles

        #region Service Locators

        // ** Lazy DI pattern

        private static HttpContext HttpContext => ServiceLocator.Resolve<IHttpContextAccessor>().HttpContext!;

        // Singleton lifetime
        private ICurrentUser currentUser = null!;
        protected ICurrentUser _currentUser => currentUser ??= HttpContext.RequestServices.GetService<ICurrentUser>()!;

        // Scoped lifetime
        protected ICache _cache => HttpContext.RequestServices.GetService<ICache>()!;
        protected UltraContext _db => HttpContext.RequestServices.GetService<UltraContext>()!;

        #endregion
    }
}
