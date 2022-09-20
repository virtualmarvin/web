using Marvin.Web.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Marvin.Web.Areas.ThingsC
{
    public class Delete : BaseModel
    {
        #region Data

        public int Id { get; set; }

        #endregion

        #region Handlers

        public override async Task<IActionResult> PostAsync()
        {
            var thingC = await _db.ThingCs.SingleOrDefaultAsync(c => c.Id == Id);
            if (thingC is not null)
            {
                _db.ThingCs.Remove(thingC);
                await _db.SaveChangesAsync();

                await SettleDeleteAsync(thingC);
            }

            return Json(true);
        }

        #endregion

        #region Helpers

        private async Task SettleDeleteAsync(ThingC thingC)
        {
            _cache.DeleteThingC(thingC);
            await _db.Database.ExecuteSqlInterpolatedAsync(
                     $"DELETE FROM Viewed WHERE WhatId = {thingC.Id} AND WhatType = 'ThingC';");

            await _rollup.RollupUserAsync(thingC.OwnerId);
        }

        #endregion
    }
}
