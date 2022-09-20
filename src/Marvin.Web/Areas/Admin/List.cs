using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Marvin.Web.Areas.Admin
{
    public class List : PagedModel<Detail>
    {
        #region Handlers

        public override async Task<IActionResult> GetAsync()
        {
            Items.Add(new Detail { Icon = _cache.ThingAIcon, Name = "Things A", Url = "/thingsa", Count = await _db.ThingAs.CountAsync() });
            Items.Add(new Detail { Icon = _cache.ThingBIcon, Name = "Things B", Url = "/thingsb", Count = await _db.ThingBs.CountAsync() });
            Items.Add(new Detail { Icon = _cache.ThingCIcon, Name = "Things C", Url = "/thingsc", Count = await _db.ThingCs.CountAsync() });
            Items.Add(new Detail { Icon = _cache.ThingDIcon, Name = "Things D", Url = "/thingsd", Count = await _db.ThingDs.CountAsync() });
            Items.Add(new Detail { Icon = _cache.ThingEIcon, Name = "Things E", Url = "/thingse", Count = await _db.ThingEs.CountAsync() });

            Items.Add(new Detail { Icon = _cache.PeopleIcon, Name = "People", Url = "/people", Count = await _db.Users.CountAsync(u => u.IsDeleted == false) });
            Items.Add(new Detail { Icon = _cache.AdminIcon, Name = "Users", Url = "/admin/users", Count = await _db.Users.CountAsync(u => u.IsDeleted == false) });
            Items.Add(new Detail { Icon = _cache.AdminIcon, Name = "Errors", Url = "/admin/errors", Count = await _db.Errors.CountAsync() });

            return View(this);
        }

        #endregion
    }
}
