using Microsoft.AspNetCore.Mvc;

namespace Marvin.Web.Areas.Admin
{
    public class Rollup : BaseModel
    {
        public override async Task<IActionResult> GetAsync()
        {
            await _rollup.RollupAllAsync();
            Success = "Rollups have been completed";
            
            return LocalRedirect("/admin");
        }
    }
}
