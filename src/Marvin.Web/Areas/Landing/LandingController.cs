using Microsoft.AspNetCore.Mvc;

namespace Marvin.Web.Areas.Landing
{
    /// <summary>
    /// Landing Controller
    /// </summary>
    public class LandingController : Controller
    {
        /// <summary>
        /// Index Page for Landing Page
        /// </summary>
        /// <returns>Landing View</returns>
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
