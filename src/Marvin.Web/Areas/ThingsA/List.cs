using Marvin.Web.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Marvin.Web.Areas.ThingsA
{
    public class List : PagedModel<Detail>
    {
        #region Data

        public List() { Sort = "Name"; }

        public string? Name { get; set; }
        public int? ThingBId { get; set; }
        public int? ThingCId { get; set; }
        public int? OwnerId { get; set; }

        #endregion

        #region Handlers

        public override async Task<IActionResult> GetAsync()
        {
            var query = BuildQuery();

            TotalRows = await query.CountAsync();
            var items = await query.Skip(Skip).Take(Take).ToListAsync();

            _mapper.Map(items, Items);

            return View(this);
        }

        #endregion

        #region Helpers

        protected IQueryable<ThingA> BuildQuery()
        {
            var query = _db.ThingAs.AsQueryable();

            // Filters

            if (AdvancedFilter)
            {
                if (Name != null)
                {
                    query = query.Where(c => c.Name.Contains(Name));
                }

                if (ThingBId != null)
                {
                    query = query.Where(c => c.ThingBId == ThingBId);
                }

                if (ThingCId != null)
                {
                    query = query.Where(c => c.ThingCId == ThingCId);
                }

                if (OwnerId != null)
                {
                    query = query.Where(c => c.OwnerId == OwnerId.Value);
                }
            }
            else
            {
                switch (Filter)
                {
                    case 1: query = query.Where(c => _viewedService.GetIds("ThingA").Contains(c.Id)); break;
                    case 2: query = query.Where(c => c.OwnerId == _currentUser.Id); break;
                }
            }

            // Sorting

            query = Sort switch
            {
                "Id" => query.OrderBy(c => c.Id),
                "-Id" => query.OrderByDescending(c => c.Id),
                "Name" => query.OrderBy(c => c.Name),
                "-Name" => query.OrderByDescending(c => c.Name),
                "ThingBName" => query.OrderBy(c => c.ThingBName),
                "-ThingBName" => query.OrderByDescending(c => c.ThingBName),
                "ThingCName" => query.OrderBy(c => c.ThingCName),
                "-ThingCName" => query.OrderByDescending(c => c.ThingCName),
                "Text" => query.OrderBy(c => c.Text),
                "-Text" => query.OrderByDescending(c => c.Text),
                "Lookup" => query.OrderBy(c => c.Lookup),
                "-Lookup" => query.OrderByDescending(c => c.Lookup),
                "TotalThingsE" => query.OrderBy(c => c.TotalThingsE),
                "-TotalThingsE" => query.OrderByDescending(c => c.TotalThingsE),
                "OwnerAlias" => query.OrderBy(c => c.OwnerAlias),
                "-OwnerAlias" => query.OrderByDescending(c => c.OwnerAlias),
                _ => query.OrderByDescending(c => c.Id),
            };

            return query;
        }


        #endregion

        #region Mapping

        // Mappings are already defined in the associated Detail.cs actionmodel

        #endregion
    }
}
