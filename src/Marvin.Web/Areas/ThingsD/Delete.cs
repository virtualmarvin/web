using Marvin.Web.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Marvin.Web.Areas.ThingsD
{
    public class Delete : BaseModel
    {
        #region Data

        public int Id { get; set; }

        #endregion

        #region Handlers

        public override async Task<IActionResult> PostAsync()
        {
            var thingD = await _db.ThingDs.SingleAsync(c => c.Id == Id);
            _db.ThingDs.Remove(thingD);
            await _db.SaveChangesAsync();

            await SettleDeleteAsync(thingD);

            return Json(true);
        }

        #endregion

        #region Helpers

        private async Task SettleDeleteAsync(ThingD thingD)
        {
            _cache.DeleteThingD(thingD);
            await _db.Database.ExecuteSqlInterpolatedAsync(
                     $"DELETE FROM Viewed WHERE WhatId = {thingD.Id} AND WhatType = 'ThingD';");

            await _rollup.RollupUserAsync(thingD.OwnerId);
        }

        #endregion
    }
}
