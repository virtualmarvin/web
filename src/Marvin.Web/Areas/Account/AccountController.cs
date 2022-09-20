using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Marvin.Web.Areas.Account
{
    [Authorize]
    [Route("account")]
    public class AccountController : Controller
    {
        #region Pages

        [HttpGet]
        public async Task<IActionResult> Detail(Detail model) => await model.GetAsync();

        [HttpGet("edit")]
        public async Task<IActionResult> Edit(int? id) => await new Edit { Id = id }.GetAsync();

        [HttpPost("edit")]
        public async Task<IActionResult> Edit(Edit model) => await model.PostAsync();

        [HttpGet("password")]
        public IActionResult Password() => new Password().Get();

        [HttpPost("password")]
        public async Task<IActionResult> Password(Password model) => await model.PostAsync();

        #endregion
    }
}
