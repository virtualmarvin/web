using Microsoft.Net.Http.Headers;

namespace Marvin.Web
{
    public static class HttpExtensions
    {
        public static string Referer(this HttpContext httpContext)
        {
            var referer = httpContext.Request?.Headers[HeaderNames.Referer];
            if (string.IsNullOrEmpty(referer)) return "";

            var uri = new Uri(referer);
            return uri.GetComponents(UriComponents.PathAndQuery, UriFormat.UriEscaped);
        }

        public static string Referer(this IHttpContextAccessor httpContextAccessor)
        {
            var referer = httpContextAccessor.HttpContext?.Request?.Headers[HeaderNames.Referer];
            if (string.IsNullOrEmpty(referer)) return "";

            var uri = new Uri(referer);
            return uri.GetComponents(UriComponents.PathAndQuery, UriFormat.UriEscaped);
        }

        public static string? PostedReferer(this HttpContext httpContext)
        {
            if (httpContext.Request.Method == "POST" &&
                httpContext.Request.Form.ContainsKey("Referer"))
                return httpContext.Request.Form["Referer"].ToString();

            return null;
        }

        public static string? PostedReferer(this IHttpContextAccessor httpContextAccessor)
        {
            var context = httpContextAccessor.HttpContext;
            if (context is not null &&
                context.Request.Method == "POST" &&
                context.Request.Form.ContainsKey("Referer"))
                return context.Request.Form["Referer"].ToString();

            return null;
        }
    }
}
