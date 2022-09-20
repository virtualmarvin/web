using Marvin.Web.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Marvin.Web.Areas.Errors
{
    public class List : PagedModel<Detail>
    {
        #region Data

        public string? DeleteCount { get; set; } // placeholder for binding

        #endregion

        #region Handlers

        public override async Task<IActionResult> GetAsync()
        {
            TotalRows = await _db.Errors.CountAsync();

            var items = _db.Errors
                           .Include(e => e.User)
                           .OrderByDescending(e => e.ErrorDate)
                           .Skip(Skip).Take(Take);

            _mapper.Map(items, Items);

            return View(this);
        }

        #endregion

        #region Mapping

        public class MapperProfile : BaseProfile
        {
            public MapperProfile()
            {
                CreateMap<Error, Detail>()
                  .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.ErrorDate.ToDateTime()))
                  .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserId != null ? _cache.Users[src.UserId.Value].Name : ""));
            }
        }

        #endregion
    }
}