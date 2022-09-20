using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Marvin.Web.Areas.Logins
{
    [Authorize(Roles = "Admin")]
    [Menu("Admin")]
    [Route("admin/logins")]
    [AdminMenu("Logins")]
    public class LoginsController : Controller
    {
        #region Pages

        [HttpGet]
        public async Task<IActionResult> List(List model) => await model.GetAsync();

        #endregion
    }
}
