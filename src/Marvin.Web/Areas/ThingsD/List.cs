using Marvin.Web.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Marvin.Web.Areas.ThingsD
{
    public class List : PagedModel<Detail>
    {
        #region Data

        public List() { Sort = "Name"; }

        public string? Name { get; set; }
        public string? Text { get; set; }
        public string? Status { get; set; }
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

        protected IQueryable<ThingD> BuildQuery()
        {
            var query = _db.ThingDs.AsQueryable();

            // Filters

            if (AdvancedFilter)
            {
                if (Name != null)
                {
                    query = query.Where(c => c.Name.Contains(Name));
                }

                if (Text != null)
                {
                    query = query.Where(c => c.Text!.Contains(Text));
                }

                if (Status != null)
                {
                    query = query.Where(c => c.Status == Status);
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
                    case 1: query = query.Where(c => _viewedService.GetIds("ThingD").Contains(c.Id)); break;
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
                "Text" => query.OrderBy(c => c.Text),
                "-Text" => query.OrderByDescending(c => c.Text),
                "Lookup" => query.OrderBy(c => c.Lookup),
                "-Lookup" => query.OrderByDescending(c => c.Lookup),
                "Status" => query.OrderBy(c => c.Status),
                "-Status" => query.OrderByDescending(c => c.Status),
                "Integer" => query.OrderBy(c => c.Integer),
                "-Integer" => query.OrderByDescending(c => c.Integer),
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

        // Mappings are already defined in the associated Detail.cs page

        #endregion
    }
}
