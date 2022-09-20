using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Marvin.Web.Areas.ThingsD
{
    public class Export : List
    {
        #region Data

        public byte[]? Bytes { get; private set; }
        public string? FileName { get; private set; }

        #endregion

        #region Handlers

        public override async Task<IActionResult> GetAsync()
        {
            var query = BuildQuery();

            Bytes = _excel.ExportThingsD(await query.ToListAsync());
            FileName = "ExcelThingsD-" + System.DateTime.Now.ToFileStampDateTime() + ".xlsx";

            return File(Bytes, "application/vnd.ms-excel", FileName);
        }

        #endregion
    }
}
