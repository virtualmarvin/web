using Microsoft.AspNetCore.Mvc;

namespace Marvin.Web.Areas.Auth
{
    [Menu("Login")]
    public class AuthController : Controller
    {
        #region Login

        [HttpGet("login")]
        public IActionResult Login(string returnUrl) => new Login { ReturnUrl = returnUrl }.Get();

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromForm]Login model) => await model.PostAsync();

        #endregion

        #region Logout

        [HttpGet("logout")]
        public async Task<IActionResult> Logout(Logout model) => await model.GetAsync();

        #endregion

        #region Activate

        [HttpGet("activate/{cd}")]
        public async Task<IActionResult> Activate(Activate model, string cd) => await model.GetAsync();

        [HttpPost("activate/{cd}")]
        public async Task<IActionResult> Activate([FromForm]Activate model) => await model.PostAsync();

        [HttpGet("activateconfirm")]
        public IActionResult ActivateConfirm() => View();

        [HttpGet("activatefailed")]
        public IActionResult ActivateFailed() => View();

        #endregion

        #region Forgot

        [HttpGet("forgot")]
        public IActionResult Forgot() => new Forgot().Get();

        [HttpPost("forgot")]
        public async Task<IActionResult> Forgot(Forgot model) => await model.PostAsync();

        [HttpGet("forgotconfirm")]
        public IActionResult ForgotConfirm() => View();

        #endregion

        #region Reset

        [HttpGet("reset/{cd}")]
        public async Task<IActionResult> Reset(Reset model, string cd) => await model.GetAsync();

        [HttpPost("reset/{cd}")]
        public async Task<IActionResult> Reset(Reset model) => await model.PostAsync();

        [HttpGet("resetconfirm")]
        public IActionResult ResetConfirm() => View();

        [HttpGet("resetfailed")]
        public IActionResult ResetFailed() => View();

        #endregion
    }
}
