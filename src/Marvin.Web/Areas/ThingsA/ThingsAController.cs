using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Marvin.Web.Areas.ThingsA
{
    [Authorize]
    [Menu("ThingsA")]
    [Route("thingsa")]
    public class ThingsAController : Controller
    {
        #region Pages

        [HttpGet]
        public async Task<IActionResult> List(List model) => await model.GetAsync();

        [HttpGet("{id}", Order = 10)]
        public async Task<IActionResult> Detail(Detail model) => await model.GetAsync();

        [HttpGet("edit/{id?}")]
        public async Task<IActionResult> Edit(int id) => await new Edit { Id = id }.GetAsync();

        [HttpPost("edit/{id?}")]
        public async Task<IActionResult> Edit(Edit model) => await model.PostAsync();
        
        [HttpPost("delete"), AjaxOnly]
        public async Task<IActionResult> Delete(Delete model) => await model.PostAsync();

        // Ancillary actions

        [HttpGet("import")]  // Step 1
        public IActionResult Import() => new Import().Get();

        [HttpPost("import")]  // Step 2
        public async Task<IActionResult> Import(IFormFile file) => await new Import 
                                                             { FormFile = file }.UploadAsync();

        [HttpPost("import/go")]   // Step 3
        public async Task<IActionResult> Import(Import model) => await model.PostAsync();

        [HttpGet("export")]
        public async Task<IActionResult> Export(Export model) => await model.GetAsync();

        #endregion
    }
}
