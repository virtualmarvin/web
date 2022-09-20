using Microsoft.AspNetCore.Mvc;

namespace Marvin.Web.Areas.Admin
{
    public class ClearCache : BaseModel
    {
        public override IActionResult Get()
        {
            _cache.Clear();
            Success = "Caches have been cleared";
            
            return LocalRedirect("/admin");
        }
    }
}
