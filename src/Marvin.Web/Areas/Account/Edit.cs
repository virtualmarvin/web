using Marvin.Web.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Marvin.Web.Areas.Account
{
    public class Edit : BaseModel
    {
        #region Data

        public int? Id { get; set; }

        [Required(ErrorMessage = "First name is required")]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required")]
        public string? LastName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Alias is required")]
        public string? Alias { get; set; }

        public string? City { get; set; }
        public string? Country { get; set; }

        #endregion

        #region Handlers

        public override async Task<IActionResult> GetAsync()
        {
            var user = await _db.Users.SingleAsync(u => u.Id == _currentUser.Id);
            Map(user, this);

            return View(this);
        }

        public override async Task<IActionResult> PostAsync()
        {
            if (!ModelState.IsValid) return View(this);

            var user = await _db.Users.SingleAsync(u => u.Id == _currentUser.Id);
            Map(this, user);

            _db.Users.Update(user);

            await _db.SaveChangesAsync();

            // Refresh claims as values may have changed
            await _identityService.RefreshClaimsAsync(user);

            return LocalRedirect("/account");
        }

        #endregion

        #region Mapping

        private void Map(User user, Edit model)
        {
            model.FirstName = user.FirstName;
            model.LastName = user.LastName;
            model.Email = user.Email;
            model.Alias = user.Alias;
            model.City = user.City;
            model.Country = user.Country;
        }

        private void Map(Edit model, User user)
        {
            user.FirstName = model.FirstName!;
            user.LastName = model.LastName!;
            user.Email = model.Email!;
            user.Alias = model.Alias!;
            user.City = model.City;
            user.Country = model.Country;
        }

        #endregion
    }
}
