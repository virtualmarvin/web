namespace Marvin.Web.Areas.Home
{
    using System.Diagnostics;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// The main website controller for Home functions
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// Website privacy page
        /// </summary>
        /// <returns></returns>
        public IActionResult Privacy()
        {
            return View();
        }

        /// <summary>
        /// The public Error view for the website
        /// </summary>
        /// <returns></returns>
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
