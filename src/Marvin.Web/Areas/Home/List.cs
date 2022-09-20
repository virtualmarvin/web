using Marvin.Web.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Marvin.Web.Areas.Home
{
    public class List : PagedModel
    {
        #region Data

        public int BronzeCount { get; set; }
        public string? BronzeAmount { get; set; }

        public int SilverCount { get; set; }
        public string? SilverAmount { get; set; }

        public int GoldCount { get; set; }
        public string? GoldAmount { get; set; }

        public int PlatinumCount { get; set; }
        public string? PlatinumAmount { get; set; }

        public string? BarChartLabels { get; set; }
        public string? BarChartValues { get; set; }

        public string? DealsByStage { get; set; }
        public string? PieChartValues { get; set; }

        public List<_ThingA> ThingsA { get; } = new();
        public List<_Viewed> Vieweds { get; } = new();

        #endregion

        #region Handlers

        private Dictionary<string, Dictionary<string, int>> buckets = new Dictionary<string, Dictionary<string, int>>();

        public override async Task<IActionResult> GetAsync()
        {
            var thingsB = await _db.ThingBs.ToListAsync();

            BronzeCount = thingsB.Count(o => o.Status == "Bronze");
            BronzeAmount = thingsB.Where(o => o.Status == "Bronze").Sum(o => o.Money).ToCurrency();

            SilverCount = thingsB.Count(o => o.Status == "Silver");
            SilverAmount = thingsB.Where(o => o.Status == "Silver").Sum(o => o.Money).ToCurrency();

            GoldCount = thingsB.Count(o => o.Status == "Gold");
            GoldAmount = thingsB.Where(o => o.Status == "Gold").Sum(o => o.Money).ToCurrency();

            PlatinumCount = thingsB.Count(o => o.Status == "Platinum");
            PlatinumAmount = thingsB.Where(o => o.Status == "Platinum").Sum(o => o.Money).ToCurrency();


            // Recently viewed records
            var viewed = _db.Vieweds.Where(v => v.UserId == _currentUser.Id)
                                   .OrderByDescending(v => v.ViewDate)
                                   .Take(6);

            _mapper.Map(viewed, Vieweds);

            // Top Things A
            var thingsA = await _db.ThingAs.OrderByDescending(o => o.Money)
                                            .Take(5).ToListAsync();

            _mapper.Map(thingsA, ThingsA);

            return View(this);
        }

        #endregion

        #region Mapping

        public class MapperProfile : BaseProfile
        {
            public MapperProfile()
            {
                CreateMap<Viewed, _Viewed>()
                    .ForMember(dest => dest.Url, opt => opt.MapFrom(src => _cache.MetaTypes[src.WhatType].Url + "/" + src.WhatId))
                    .ForMember(dest => dest.Icon, opt => opt.MapFrom(src => _cache.MetaTypes[src.WhatType].Icon))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.WhatName));

                CreateMap<ThingA, _ThingA>()
                    .ForMember(dest => dest.Money, opt => opt.MapFrom(src => src.Money.ToCurrency()))
                    .ForMember(dest => dest.DateTime, opt => opt.MapFrom(src => src.DateTime.ToDate()));
            }
        }

        #endregion
    }
}
