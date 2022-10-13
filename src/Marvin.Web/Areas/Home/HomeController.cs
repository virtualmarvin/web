using Microsoft.AspNetCore.Mvc;

namespace Marvin.Web.Areas.Home
{
    /// <summary>
    /// The main website controller for Home functions
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Website privacy page
        /// </summary>
        /// <returns></returns>
        [HttpGet("Privacy")]
        public IActionResult Privacy()
        {
            return View();
        }
    }
}
