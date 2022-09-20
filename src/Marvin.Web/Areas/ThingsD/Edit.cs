using Marvin.Web.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Marvin.Web.Areas.ThingsD
{
    public class Edit : BaseModel
    {
        #region Data

        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }

        public string? Text { get; set; }
        public string? Lookup { get; set; }
        public decimal? Money { get; set; }
        public string? DateTime { get; set; }
        public string? Status { get; set; }
        public int? Integer { get; set; }
        public bool? Boolean { get; set; }
        public string? LongText { get; set; }

        public int? OwnerId { get; set; }
        public string? OwnerAlias { get; set; }
        public string? OwnerName { get; set; }

        #endregion

        #region Handlers

        public override async Task<IActionResult> GetAsync()
        {
            if (Id == 0)
            {
                OwnerId = _currentUser.Id;
                OwnerName = _currentUser.Name;
            }
            else
            {
                _mapper.Map(await _db.ThingDs.SingleOrDefaultAsync(c => c.Id == Id), this);
            }

            return View(this);
        }

        public override async Task<IActionResult> PostAsync()
        {
            if (!ModelState.IsValid) return View(this);

            if (Id == 0) // new item
            {
                var thingD = _mapper.Map<ThingD>(this);

                _db.ThingDs.Add(thingD);
                await _db.SaveChangesAsync();

                await SettleInsertAsync(thingD);
            }
            else
            {
                var thingD = await _db.ThingDs.SingleAsync(c => c.Id == Id);
                var originalThingD = new OriginalThingD(thingD);

                _mapper.Map(this, thingD);

                _db.ThingDs.Update(thingD);
                await _db.SaveChangesAsync();

                await SettleUpdateAsync(originalThingD, thingD);
            }

            return LocalRedirect(Referer ?? "/thingds");
        }

        #endregion

        #region Helpers

        private async Task SettleInsertAsync(ThingD thingD)
        {
            _cache.MergeThingD(thingD);

            await _rollup.RollupUserAsync(thingD.OwnerId);
        }

        private async Task SettleUpdateAsync(OriginalThingD original, ThingD thingD)
        {
            _cache.MergeThingD(thingD);


            if (original.OwnerId != thingD.OwnerId)
            {
                await _rollup.RollupUserAsync(original.OwnerId);
                await _rollup.RollupUserAsync(thingD.OwnerId);
            }
        }

        private class OriginalThingD
        {
            // Used to temporarily hold a copy of the relevant fields

            public int OwnerId { get; set; }

            public OriginalThingD(ThingD thingD)
            {
                OwnerId = thingD.OwnerId;
            }
        }

        #endregion

        #region Mapping

        public class MapperProfile : BaseProfile
        {
            public MapperProfile()
            {
                CreateMap<ThingD, Edit>()
                   .ForMember(dest => dest.DateTime, opt => opt.MapFrom(src => src.DateTime.ToDate()))
                   .ForMember(dest => dest.OwnerName, opt => opt.MapFrom(src => src.OwnerId == 0 ? "" : _cache.Users[src.OwnerId].Name));

                CreateMap<Edit, ThingD>()
                   .ForMember(dest => dest.DateTime, opt => opt.MapFrom(src => src.DateTime!.TransformToDate()))
                   .ForMember(dest => dest.OwnerAlias, opt => opt.MapFrom(src => _cache.Users[src.OwnerId!.Value].Alias));
            }
        }

        #endregion
    }
}
