using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Marvin.Web.Areas.Account
{
    public class Password : BaseModel
    {
        #region Data

        [Required(ErrorMessage = "Current Password is required")]
        [DataType(DataType.Password)]
        public string? CurrentPassword { get; set; }

        [Required(ErrorMessage = "New Password is required")]
        [StringLength(50, MinimumLength = 7, ErrorMessage = "Min password length is 7 characters")]
        [DataType(DataType.Password)]
        public string? NewPassword { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [StringLength(50, MinimumLength = 7, ErrorMessage = "Min password length is 7 characters")]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "New Password and Confirmation Password do not match")]
        public string? ConfirmPassword { get; set; }

        #endregion

        #region Handlers

        public override async Task<IActionResult> PostAsync()
        {
            if (!ModelState.IsValid) return View(this);

            var user = await _db.Users.SingleAsync(u => u.Id == _currentUser.Id);

            var result = await _identityService.ChangePasswordAsync(user, CurrentPassword!, NewPassword!);
            if (result.Succeeded)
            {
                Success = "Password has been changed";
            }
            else
            {
                Failure = "Password update failed";
            }

            return LocalRedirect("/account");
        }

        #endregion
    }
}
