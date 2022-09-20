using Microsoft.AspNetCore.Mvc;

namespace Marvin.Web.Areas.Auth
{
    public class Logout : BaseModel
    {
        #region Handlers

        public override async Task<IActionResult> GetAsync()
        {
             await _identityService.SignOutAsync();

             return RedirectToAction("Login");
        }

        #endregion
    }
}
