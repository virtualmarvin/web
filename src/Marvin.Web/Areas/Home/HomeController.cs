using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Marvin.Web.Areas.Home
{
    [Authorize]
    [Menu("Home")]
    public class HomeController: Controller
    {
        #region Pages

        [HttpGet("home")]
        public async Task<IActionResult> List(List model) => await model.GetAsync();

        [HttpGet("recents")]
        public async Task<IActionResult> Recents(Recents model) => await model.GetAsync();

        #endregion
    }
}
