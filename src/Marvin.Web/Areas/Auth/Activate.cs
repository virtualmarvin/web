using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Marvin.Web.Areas.Auth
{
    public class Activate : BaseModel
    {
        #region Data

        public string? Cd { get; set; } // activation code

        [Required(ErrorMessage = "New password is required")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "Password must be at least 8 characters long.", MinimumLength = 8)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,35}$", ErrorMessage = "Password must be at least 8 characters long and contain 1 uppercase letter, 1 lowercase letter, 1 number, and 1 special character")]
        public string? NewPassword { get; set; }

        [Required(ErrorMessage = "Confirmation password is required")]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Password and Confirmation password do not match")]
        public string? ConfirmPassword { get; set; }

        #endregion

        #region Handlers

        public override async Task<IActionResult> GetAsync()
        {
            var user = await _db.Users.SingleOrDefaultAsync(u => u.ActivationCode == Cd && u.ActivationDate == null);
            if (user != null) return View(this);

            return RedirectToAction("ActivateFailed");
        }

        public override async Task<IActionResult> PostAsync()
        {
            var user = _db.Users.Single(u => u.ActivationCode == Cd && u.ActivationDate == null);
            if (user != null && NewPassword != null)
            {
                await _identityService.ResetPasswordAsync(user, NewPassword);

                user.ActivationDate = DateTime.Now;
                _db.Users.Update(user);
                await _db.SaveChangesAsync();

                return RedirectToAction("ActivateConfirm");
            }

            Failure = "Account activation was unsuccessful.";

            return View(this);
        }

        #endregion
    }
}