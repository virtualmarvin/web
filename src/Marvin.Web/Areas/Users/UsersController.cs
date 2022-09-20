using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Marvin.Web.Areas.Users
{
    [Authorize(Roles ="Admin")]
    [Menu("Admin")]
    [Route("admin/users")]
    [AdminMenu("Users")]
    public class UsersController : Controller
    {
        #region Pages

        [HttpGet]
        public async Task<IActionResult> List(List model) => await model.GetAsync();

        [HttpGet("{id}", Order = 10)]
        public async Task<IActionResult> Detail(Detail model) => await model.GetAsync();

        [HttpGet("edit/{id?}")]
        public async Task<IActionResult> Edit(int id) => await new Edit { Id = id }.GetAsync();

        [HttpPost("edit/{id?}")]
        public async Task<IActionResult> Edit(Edit model) => await model.PostAsync();

        [HttpPost("delete"), AjaxOnly]
        public async Task<IActionResult> Delete(Delete model) => await model.PostAsync();

        // Ancillary actions

        [HttpGet("resend/{id?}")]
        public async Task<IActionResult> Resend(Resend model) => await model.PostAsync();

        #endregion
    }
}
