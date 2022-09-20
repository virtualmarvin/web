using Marvin.Web.Areas._Related;
using Marvin.Web.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Marvin.Web.Areas.ThingsB
{
    public class Detail : BaseModel
    {
        #region Data

        public int Id { get; set; }

        public string? Name { get; set; }
        public string? Text { get; set; }
        public string? Lookup { get; set; }
        public string? Money { get; set; }
        public string? DateTime { get; set; }
        public string? Status { get; set; }
        public int? Integer { get; set; }
        public bool? Boolean { get; set; }
        public string? LongText { get; set; }
        public int TotalThingsA { get; set; }

        public int? OwnerId { get; set; }
        public string? OwnerAlias { get; set; }
        public string? OwnerName { get; set; }

        // Related Lists
        public string Tab { get; set; } = "details";
        public _ThingsA ThingsA { get; set; } = new() { ParentIdName = "ThingBId" };

        #endregion

        #region Handlers

        public override async Task<IActionResult> GetAsync()
        {
            var thingB = await _db.ThingBs.SingleAsync(c => c.Id == Id);
            _mapper.Map(thingB, this);

            // Relateds

            var thingsA = await _db.ThingAs.Where(o => o.ThingBId == thingB.Id).OrderByDescending(o => o.Id).Take(4).ToListAsync();
            if (thingsA is not null)
            {
                _related.Prepare(thingsA, ThingsA, thingB.TotalThingsA, thingB.Id, thingB.Name);
                await _viewedService.Log(Id, "ThingB", thingB.Name);
            }

            return View(this);
        }

        #endregion

        #region Mapping

        public class MapperProfile : BaseProfile
        {
            public MapperProfile()
            {
                CreateMap<ThingB, Detail>()
                  .ForMember(dest => dest.DateTime, opt => opt.MapFrom(src => src.DateTime.ToDate()))
                  .ForMember(dest => dest.OwnerName, opt => opt.MapFrom(src => _cache.Users[src.OwnerId].Name));
            }
        }

        #endregion
    }
}
