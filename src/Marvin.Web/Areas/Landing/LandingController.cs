using Microsoft.AspNetCore.Mvc;

namespace Marvin.Web.Areas.Landing
{
    public class LandingController : Controller
    {
        #region Pages

        [HttpGet("")]
        public IActionResult Landing() => View();

        [HttpGet("error")]
        public IActionResult Error(Error model) => model.Get();

        // Catches all requests for which there is no route handler

        [Route("{*url}", Order = 9999)]
        public IActionResult CatchAll(CatchAll model) => model.GetOrPost();

        #endregion
    }
}
