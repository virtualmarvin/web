using Marvin.Web.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Marvin.Web.Areas.Users
{
    public class Delete : BaseModel
    {
        #region Data 

        public int Id { get; set; }

        #endregion

        #region Handlers

        public override async Task<IActionResult> PostAsync()
        {
            var user = await _db.Users.SingleAsync(u => u.Id == Id);

            user.IsDeleted = true;
            user.DeletedBy = _currentUser.Id;
            user.DeletedOn = DateTime.Now;

            _db.Users.Update(user);
            await _db.SaveChangesAsync();

            SettleDelete(user);

            return Json(true);
        }

        #endregion

        #region Helpers

        private void SettleDelete(User user)
        {
            // Softdelete
            _cache.MergeUser(user);
        }

        #endregion
    }
}
