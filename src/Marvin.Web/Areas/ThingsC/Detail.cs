using Marvin.Web.Areas._Related;
using Marvin.Web.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Marvin.Web.Areas.ThingsC
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
        public bool Boolean { get; set; }
        public string? LongText { get; set; }
        public int TotalThingsA { get; set; }

        public int? OwnerId { get; set; }
        public string? OwnerAlias { get; set; }
        public string? OwnerName { get; set; }

        // Related Lists
        public string Tab { get; set; } = "details";
        public _ThingsA ThingsA { get; set; } = new(){ ParentIdName = "ThingCId" };

        #endregion

        #region Handlers

        public override async Task<IActionResult> GetAsync()
        {
            var thingC = await _db.ThingCs.SingleAsync(c => c.Id == Id)!;
            _mapper.Map(thingC, this);

            // Relateds

            var thingsA = await _db.ThingAs.Where(o => o.ThingCId == thingC.Id).OrderByDescending(o => o.Id).Take(4).ToListAsync();
            _related.Prepare(thingsA, ThingsA, thingC.TotalThingsA, thingC.Id, thingC.Name!);

            await _viewedService.Log(Id, "ThingC", thingC.Name!);

            return View(this);
        }

        #endregion

        #region Mapping

        public class MapperProfile : BaseProfile
        {
            public MapperProfile()
            {
                CreateMap<ThingC, Detail>()
                   .ForMember(dest => dest.Money, opt => opt.MapFrom(src => src.Money.ToCurrency()))
                   .ForMember(dest => dest.DateTime, opt => opt.MapFrom(src => src.DateTime.ToDate()))
                   .ForMember(dest => dest.Boolean, opt => opt.MapFrom(src => src.Boolean ?? false))
                   .ForMember(dest => dest.OwnerName, opt => opt.MapFrom(src => _cache.Users[src.OwnerId].Name));
            }
        }

        #endregion
    }
}
