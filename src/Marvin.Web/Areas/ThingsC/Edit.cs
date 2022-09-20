using Marvin.Web.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Marvin.Web.Areas.ThingsC
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
                _mapper.Map(await _db.ThingCs.SingleOrDefaultAsync(c => c.Id == Id), this);
            }

            return View(this);
        }

        public override async Task<IActionResult> PostAsync()
        {
            if (!ModelState.IsValid) return View(this);

            if (Id == 0) // new item
            {
                var thingC = _mapper.Map<ThingC>(this);

                _db.ThingCs.Add(thingC);
                await _db.SaveChangesAsync();

                await SettleInsertAsync(thingC);
            }
            else
            {
                var thingC = await _db.ThingCs.SingleAsync(c => c.Id == Id);
                var originalThingC = new OriginalThingC(thingC);

                _mapper.Map(this, thingC);

                _db.ThingCs.Update(thingC);
                await _db.SaveChangesAsync();

                await SettleUpdateAsync(originalThingC, thingC);
            }

            return LocalRedirect(Referer ?? "/thingcs");
        }

        #endregion

        #region Helpers

        private async Task SettleInsertAsync(ThingC thingC)
        {
            _cache.MergeThingC(thingC);

            await _rollup.RollupUserAsync(thingC.OwnerId);
        }

        private async Task SettleUpdateAsync(OriginalThingC original, ThingC thingC)
        {
            _cache.MergeThingC(thingC);


            if (original.OwnerId != thingC.OwnerId)
            {
                await _rollup.RollupUserAsync(original.OwnerId);
                await _rollup.RollupUserAsync(thingC.OwnerId);
            }
        }


        private class OriginalThingC
        {
            // Used to temporarily hold a copy of the relevant fields

            public int OwnerId { get; set; }

            public OriginalThingC(ThingC thingC)
            {
                OwnerId = thingC.OwnerId;
            }
        }

        #endregion

        #region Mapping

        public class MapperProfile : BaseProfile
        {
            public MapperProfile()
            {
                CreateMap<ThingC, Edit>()
                   .ForMember(dest => dest.DateTime, opt => opt.MapFrom(src => src.DateTime.ToDate()))
                   .ForMember(dest => dest.OwnerName, opt => opt.MapFrom(src => src.OwnerId == 0 ? "" : _cache.Users[src.OwnerId].Name));

                CreateMap<Edit, ThingC>()
                   .ForMember(dest => dest.DateTime, opt => opt.MapFrom(src => src.DateTime!.TransformToDate()))
                   .ForMember(dest => dest.OwnerAlias, opt => opt.MapFrom(src => _cache.Users[src.OwnerId!.Value].Alias));
            }
        }

        #endregion
    }
}
