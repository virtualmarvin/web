using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Marvin.Web.Areas.Home
{
    public class Recents : PagedModel<_Viewed>
    {
        #region Handlers

        public override async Task<IActionResult> GetAsync()
        {
            var viewed = _db.Vieweds.AsQueryable();
            viewed = viewed.Where(v => v.UserId == _currentUser.Id)
                           .OrderByDescending(v => v.ViewDate);

            TotalRows = viewed.Count();
            var items = await viewed.Skip(Skip).Take(Take).ToListAsync();

            _mapper.Map(items, Items);

            return View(this);
        }

        #endregion

        #region Mapping

        // Already mapped in this module's List.cs file.

        #endregion
    }
}
