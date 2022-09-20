using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Marvin.Web.Areas.Auth
{
    public class Login : BaseModel
    {
        #region Data

        [Required(ErrorMessage = "Email is required.")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        public bool RememberMe { get; set; }

        public string? ReturnUrl { get; set; }

        #endregion

        #region Handlers

        public override async Task<IActionResult> PostAsync()
        {
            var login = new Domain.Login
            {
                Email = Email!,
                IpAddress = HttpContext.Connection.RemoteIpAddress?.ToString(),
                LoginDate = DateTime.Now,
                CreatedOn = DateTime.Now,
                ChangedOn = DateTime.Now
            };

            if (ModelState.IsValid)
            {
                var result = await _identityService.PasswordSignInAsync(Email!, Password!);
                if (result.Succeeded)
                {
                    var user = _db.Users.SingleOrDefault(u => u.Email == Email);
                    if (user != null)
                    {
                        login.UserId = user.Id;
                        login.FirstName = user.FirstName;
                        login.LastName = user.LastName;

                        login.Result = "Success";
                        _db.Logins.Add(login);
                        await _db.SaveChangesAsync();

                        user.LastLoginDate = DateTime.Now;
                        _db.Users.Update(user);
                        await _db.SaveChangesAsync();

                        return LocalRedirect(ReturnUrl ?? "/home");
                    }
                }
            }

            login.Result = "Failure";
            _db.Logins.Add(login);
            await _db.SaveChangesAsync();

            Failure = "Login was unsuccessful";
            return View(this);
        }

        #endregion
    }
}
