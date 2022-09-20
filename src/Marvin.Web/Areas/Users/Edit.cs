using Marvin.Web.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Marvin.Web.Areas.Users
{
    public class Edit : BaseModel
    {
        #region Data

        public int Id { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        public string? LastName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Alias is required")]
        public string? Alias { get; set; }

        public string? City { get; set; }
        public string? Country { get; set; }
        public string? EmployeeNumber { get; set; }
        public string? Department { get; set; }
        [Required(ErrorMessage = "Role is required")]
        public string? Role { get; set; }

        #endregion

        #region Handlers

        public override async Task<IActionResult> GetAsync()
        {
            var user = Id == 0 ? new User() : await _db.Users.SingleAsync(u => u.Id == Id);
            _mapper.Map(user, this);

            return View(this);
        }

        public override async Task<IActionResult> PostAsync()
        {
            if (!ModelState.IsValid) return View(this);

            if (Id == 0)
            {
                var user = _mapper.Map<User>(this);

                // activation is emailed to user
                user.ActivationCode = Crypto.RandomString(7);
                await _identityService.CreateUserAsync(user, null, user.Role);

                _email.SendActivationMessage(user);
                Success = "Activation email has been sent";

                SettleInsert(user);
            }
            else
            {
                var user = await _db.Users.SingleAsync(u => u.Id == Id);

                _mapper.Map(this, user);

                _db.Users.Update(user);
                await _db.SaveChangesAsync();

                SettleUpdate(user);
            }

            return LocalRedirect(Referer ?? "/admin/users");
        }

        #endregion

        #region Helpers

        private void SettleInsert(User user)
        {
            _cache.MergeUser(user);
        }

        private void SettleUpdate(User user)
        {
            _cache.MergeUser(user);
        }

        #endregion

        #region Mapping

        public class MapperProfile : BaseProfile
        {
            public MapperProfile()
            {
                CreateMap<User, Edit>();
                CreateMap<Edit, User>();
            }
        }

        #endregion
    }
}
