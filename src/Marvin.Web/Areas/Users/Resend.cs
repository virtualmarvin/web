using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Marvin.Web.Areas.Users
{
    public class Resend : BaseModel
    {
        #region Data

        public int Id { get; set; }

        #endregion

        #region Handler

        public override async Task<IActionResult> PostAsync()
        {
            var user = await _db.Users.SingleAsync(u => u.Id == Id);

            user.ActivationCode = Crypto.RandomString(7);
            user.ActivationDate = null;

            _db.Users.Update(user);

            await _db.SaveChangesAsync();

            _email.SendActivationMessage(user);

            Success = "Activation code has been sent";

            return LocalRedirect(Referer ?? "/admin/users");
        }

        #endregion
    }
}
