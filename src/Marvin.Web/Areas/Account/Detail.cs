using Marvin.Web.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Marvin.Web.Areas.Account
{
    public class Detail : BaseModel
    {
        #region Data

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
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

        #endregion

        #region Mapping

        private void Map(User user, Detail model)
        {
            model.FirstName = user.FirstName;
            model.LastName = user.LastName;
            model.Email = user.Email;
            model.Alias = user.Alias;
            model.City = user.City;
            model.Country = user.Country;
        }
        #endregion
    }
}

