using Microsoft.AspNetCore.Mvc;

namespace Marvin.Web.Areas.ThingsE
{
    public class Import : BaseModel
    {
        #region Data

        public int Step { get; set; } = 1;
        public string? FileName { get; set; }
        public DataGrid Grid { get; set; } = new();
        public string? Result { get; set; }

        public IFormFile FormFile { get; set; } = null!;

        #endregion

        #region Handlers

        public async Task<IActionResult> Upload()
        {
            try
            {
                (string fileName, DataGrid grid) = await _excel.SaveAsync(FormFile);
                return View(new Import { Step = 2, FileName = fileName, Grid = grid });
            }
            catch (ImportException ex)
            {
                Failure = ex.Message;
                return View(new Import { Step = 1 });
            }
        }

        public override async Task<IActionResult> PostAsync()
        {
            try
            {
                (int count, int total) = await _excel.ImportThingsEAsync(FileName!);
                await SettleImportAsync();

                return View(new Import { Step = 3, Result = count + " of " + total + " records were successfully imported!" });

            }
            catch (ImportException ex)
            {
                Failure = ex.Message;
                return View(new Import { Step = 1 });
            }
        }

        #endregion

        #region Helpers

        private async Task SettleImportAsync()
        {
            await _rollup.RollupUserAsync(_currentUser.Id);

            _cache.ClearThingsE();
        }

        #endregion
    }
}
