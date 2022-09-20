using Marvin.Web.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Marvin.Web.Areas.ThingsE
{
    public class Edit : BaseModel
    {
        #region Data

        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }

        public int? ThingAId { get; set; }
        public string? ThingAName { get; set; }
        public int? ThingDId { get; set; }
        public string? ThingDName { get; set; }

        public string? Text { get; set; }
        public string? Lookup { get; set; }
        public string? Status { get; set; }
        public string? Money { get; set; }
        public string? DateTime { get; set; }
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
                ThingAId = HttpContext.Request.Query["ThingAId"].GetId();
                ThingAName = HttpContext.Request.Query["ThingAName"];
                ThingDId = HttpContext.Request.Query["ThingDId"].GetId();
                ThingDName = HttpContext.Request.Query["ThingDName"];
            }
            else
            {
                _mapper.Map(await _db.ThingEs.SingleOrDefaultAsync(c => c.Id == Id), this);
            }

            return View(this);
        }

        public override async Task<IActionResult> PostAsync()
        {
            if (!ModelState.IsValid) return View(this);

            if (Id == 0) // new item
            {
                var thingE = _mapper.Map<ThingE>(this);

                _db.ThingEs.Add(thingE);
                await _db.SaveChangesAsync();

                await SettleInsertAsync(thingE);
            }
            else
            {
                var thingE = await _db.ThingEs.SingleOrDefaultAsync(c => c.Id == Id);
                if (thingE is not null)
                {
                    var originalThingE = new OriginalThingE(thingE);

                    _mapper.Map(this, thingE);

                    _db.ThingEs.Update(thingE);
                    await _db.SaveChangesAsync();

                    await SettleUpdateAsync(originalThingE, thingE);
                }
            }

            return LocalRedirect(Referer ?? "/thinges");
        }

        #endregion

        #region Helpers

        private async Task SettleInsertAsync(ThingE thingE)
        {
            _cache.MergeThingE(thingE);

            await _rollup.RollupThingAAsync(thingE.ThingAId);
            await _rollup.RollupThingDAsync(thingE.ThingDId);
            await _rollup.RollupUserAsync(thingE.OwnerId);
        }

        private async Task SettleUpdateAsync(OriginalThingE original, ThingE thingE)
        {
            _cache.MergeThingE(thingE);

            if (original.ThingAId != thingE.ThingAId)
            {
                await _rollup.RollupThingAAsync(original.ThingAId);
                await _rollup.RollupThingAAsync(thingE.ThingAId);
            }
            if (original.ThingDId != thingE.ThingDId)
            {
                await _rollup.RollupThingDAsync(original.ThingDId);
                await _rollup.RollupThingDAsync(thingE.ThingDId);
            }
            if (original.OwnerId != thingE.OwnerId)
            {
                await _rollup.RollupUserAsync(original.OwnerId);
                await _rollup.RollupUserAsync(thingE.OwnerId);
            }
        }


        private class OriginalThingE
        {
            // Used to temporarily hold a copy of the relevant fields

            public int? ThingAId { get; set; }
            public int? ThingDId { get; set; }
            public int OwnerId { get; set; }

            public OriginalThingE(ThingE thingE)
            {
                ThingAId = thingE.ThingAId;
                ThingDId = thingE.ThingDId;
                OwnerId = thingE.OwnerId;
            }
        }

        #endregion

        #region Mapping

        public class MapperProfile : BaseProfile
        {
            public MapperProfile()
            {
                CreateMap<ThingE, Edit>()
                 .ForMember(dest => dest.DateTime, opt => opt.MapFrom(src => src.DateTime.ToDate()))
                 .ForMember(dest => dest.OwnerName, opt => opt.MapFrom(src => src.OwnerId == 0 ? "" : _cache.Users[src.OwnerId].Name));

                CreateMap<Edit, ThingE>()
                 .ForMember(dest => dest.DateTime, opt => opt.MapFrom(src => src.DateTime!.TransformToDate()))
                 .ForMember(dest => dest.OwnerAlias, opt => opt.MapFrom(src => _cache.Users[src.OwnerId!.Value].Alias))
                 .ForMember(dest => dest.ThingAName, opt => opt.MapFrom(src => src.ThingAId.IsNullOrZero() ? null : _cache.ThingsA[src.ThingAId!.Value].Name))
                 .ForMember(dest => dest.ThingDName, opt => opt.MapFrom(src => src.ThingDId.IsNullOrZero() ? null : _cache.ThingsD[src.ThingDId!.Value].Name));
            }
        }

        #endregion
    }
}
