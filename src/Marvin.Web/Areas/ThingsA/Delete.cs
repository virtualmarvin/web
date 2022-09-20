using Marvin.Web.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Marvin.Web.Areas.ThingsA
{
    public class Delete : BaseModel
    {
        #region Data

        public int Id { get; set; }

        #endregion

        #region Handlers

        public override async Task<IActionResult> PostAsync()
        {
            var thingA = await _db.ThingAs.SingleAsync(c => c.Id == Id);

            _db.ThingAs.Remove(thingA);
            await _db.SaveChangesAsync();

            await SettleDeleteAsync(thingA);

            return Json(true);
        }

        #endregion

        #region Helpers

        private async Task SettleDeleteAsync(ThingA thingA)
        {
            _cache.DeleteThingA(thingA);
            await _db.Database.ExecuteSqlInterpolatedAsync(
                 $"DELETE FROM Viewed WHERE WhatId = {thingA.Id} AND WhatType = 'ThingA';");

            await _rollup.RollupThingBAsync(thingA.ThingBId);
            await _rollup.RollupThingCAsync(thingA.ThingCId);
            await _rollup.RollupUserAsync(thingA.OwnerId);
        }

        #endregion
    }
}
