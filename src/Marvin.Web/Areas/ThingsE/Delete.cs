using Marvin.Web.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Marvin.Web.Areas.ThingsE
{
    public class Delete : BaseModel
    {
        #region Data

        public int Id { get; set; }

        #endregion

        #region Handlers

        public override async Task<IActionResult> PostAsync()
        {
            var thingE = await _db.ThingEs.SingleOrDefaultAsync(c => c.Id == Id);
            if (thingE is not null)
            {
                _db.ThingEs.Remove(thingE);
                await _db.SaveChangesAsync();

                await SettleDeleteAsync(thingE);
            }

            return Json(true);
        }

        #endregion

        #region Helpers

        private async Task SettleDeleteAsync(ThingE thingE)
        {
            _cache.DeleteThingE(thingE);
            await _db.Database.ExecuteSqlInterpolatedAsync(
                $"DELETE FROM Viewed WHERE WhatId = {thingE.Id} AND WhatType = 'ThingE';");

            await _rollup.RollupThingAAsync(thingE.ThingAId);
            await _rollup.RollupThingDAsync(thingE.ThingDId);
            await _rollup.RollupUserAsync(thingE.OwnerId);
        }

        #endregion
    }
}
