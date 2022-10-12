using Microsoft.AspNetCore.Mvc;

namespace Marvin.Web.Areas.Landing
{
    public class LandingController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
