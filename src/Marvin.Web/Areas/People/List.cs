using Marvin.Web.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Marvin.Web.Areas.People
{
    public class List : PagedModel<Detail>
    {
        #region Data

        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Department { get; set; }
        public string? Role { get; set; }

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

        protected IQueryable<User> BuildQuery()
        {
            var query = _db.Users.AsQueryable().Where(a => a.IsDeleted == false);

            // Filters

            if (AdvancedFilter)
            {
                if (Name != null)
                {
                    query = query.Where(c => c.FirstName.Contains(Name) || c.LastName.Contains(Name));
                }

                if (Email != null)
                {
                    query = query.Where(c => c.Email.Contains(Email));
                }

                if (Department != null)
                {
                    query = query.Where(c => c.Department!.Contains(Department));
                }

                if (Role != null)
                {
                    query = query.Where(c => c.Role == Role);
                }
            }
            else
            {
                switch (Filter)
                {
                    case 1: query = query.Where(c => c.Department == _cache.Users[_currentUser.Id].Department); break;
                    case 2: query = query.Where(c => c.Role == "Admin"); break;
                    case 3: query = query.Where(c => c.Role == "User"); break;
                }
            }


            // Sorting

            query = Sort switch
            {
                "LastName" => query.OrderBy(u => u.LastName),
                "-LastName" => query.OrderByDescending(u => u.LastName),
                "Email" => query.OrderBy(u => u.Email),
                "-Email" => query.OrderByDescending(u => u.Email),
                "Alias" => query.OrderBy(u => u.Alias),
                "-Alias" => query.OrderByDescending(u => u.Alias),
                "EmployeeNumber" => query.OrderBy(u => u.EmployeeNumber),
                "-EmployeeNumber" => query.OrderByDescending(u => u.EmployeeNumber),
                "Department" => query.OrderBy(u => u.Department),
                "-Department" => query.OrderByDescending(u => u.Department),
                "Role" => query.OrderBy(u => u.Role),
                "-Role" => query.OrderByDescending(u => u.Role),
                "LastLoginDate" => query.OrderBy(u => u.LastLoginDate),
                "-LastLoginDate" => query.OrderByDescending(u => u.LastLoginDate),
                "Id" => query.OrderBy(u => u.Id),
                "-Id" => query.OrderByDescending(u => u.Id),
                _ => query.OrderByDescending(u => u.Id),
            };

            return query;
        }

        #endregion
    }
}
