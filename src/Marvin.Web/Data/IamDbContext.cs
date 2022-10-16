using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Marvin.Web.Data
{
    /// <summary>
    /// Identity and Access Management Data Context
    /// </summary>
    public class IamDbContext : IdentityDbContext
    {
        /// <summary>
        /// Identity and Access Management Data Context
        /// </summary>
        /// <param name="options">Identity and Access Management Data Context Options</param>
        public IamDbContext(DbContextOptions<IamDbContext> options)
            : base(options)
        {
        }
    }
}