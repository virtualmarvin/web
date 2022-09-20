using Marvin.Web.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Marvin.Web.Areas.People
{
    public class Detail : BaseModel
    {
        #region Data

        public int Id { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Alias { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? EmployeeNumber { get; set; }
        public string? Department { get; set; }
        public string? LastLoginDate { get; set; }

        public int TotalThingsA { get; set; }
        public int TotalThingsB { get; set; }
        public int TotalThingsC { get; set; }
        public int TotalThingsD { get; set; }
        public int TotalThingsE { get; set; }

        public string? Role { get; set; }

        #endregion

        #region Handlers

        public override async Task<IActionResult> GetAsync()
        {
            var user = await _db.Users.SingleAsync(c => c.Id == Id);
            _mapper.Map(user, this);

            return View(this);
        }

        #endregion

        #region Mapping

        public class MapperProfile : BaseProfile
        {
            public MapperProfile()
            {
                CreateMap<User, Detail>()
                  .ForMember(dest => dest.LastLoginDate, opt => opt.MapFrom(src => src.LastLoginDate.ToDateTime()));
            }
        }

        #endregion
    }
}
