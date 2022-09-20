using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Marvin.Web.Domain;

namespace Marvin.Web
{
    // Central Excel import / export facility

    #region Interface

    public interface IExcel
    {
        byte[] ExportThingsA(List<ThingA> thingsA);
        byte[] ExportThingsB(List<ThingB> thingsB);
        byte[] ExportThingsC(List<ThingC> thingsC);
        byte[] ExportThingsD(List<ThingD> thingsD);
        byte[] ExportThingsE(List<ThingE> thingsE);
        byte[] ExportPeople(List<User> users);

        Task<(string fileName, DataGrid grid)> SaveAsync(IFormFile file);

        Task<(int, int)> ImportThingsAAsync(string fileName);
        Task<(int, int)> ImportThingsBAsync(string fileName);
        Task<(int, int)> ImportThingsCAsync(string fileName);
        Task<(int, int)> ImportThingsDAsync(string fileName);
        Task<(int, int)> ImportThingsEAsync(string fileName);
    }
    #endregion

    public class Excel : IExcel
    {
        #region Dependency Injection

        private readonly IWebHostEnvironment _env;
        private readonly ICurrentUser _currentUser;
        private readonly UltraContext _db;
        private readonly ICache _cache;
        private readonly ILoggerFactory _loggerFactory;

        private string Qualify(string fileName) => Path.Combine(_env.ContentRootPath, @"Data\Imports", fileName);

        public Excel(IWebHostEnvironment env, ICurrentUser currentUser, UltraContext db,
                    ICache cache, ILoggerFactory loggerFactory)
        {
            _env = env;
            _currentUser = currentUser;
            _db = db;
            _cache = cache;
            _loggerFactory = loggerFactory;
        }

        #endregion

        #region Export

        public byte[] ExportThingsA(List<ThingA> thingsA)
        {
            var stream = new MemoryStream();

            using (var document = SpreadsheetDocument.Create(stream, SpreadsheetDocumentType.Workbook))
            {
                var workbookPart = document.AddWorkbookPart();
                workbookPart.Workbook = new();

                var worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                worksheetPart.Worksheet = new();

                var sheets = workbookPart.Workbook.AppendChild(new Sheets());
                var sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "Sheet1" };
                sheets.Append(sheet);

                workbookPart.Workbook.Save();

                var sheetData = worksheetPart.Worksheet.AppendChild(new SheetData());

                // Constructing header
                var row = new Row();

                row.Append(
                    CreateCell("Id", CellValues.String),
                    CreateCell("Name", CellValues.String),
                    CreateCell("ThingBId", CellValues.String),
                    CreateCell("ThingBName", CellValues.String),
                    CreateCell("ThingCId", CellValues.String),
                    CreateCell("ThingCName", CellValues.String),
                    CreateCell("Text", CellValues.String),
                    CreateCell("Lookup", CellValues.String),
                    CreateCell("Money", CellValues.String),
                    CreateCell("DateTime", CellValues.String),
                    CreateCell("Status", CellValues.String),
                    CreateCell("Integer", CellValues.String),
                    CreateCell("Boolean", CellValues.String),
                    CreateCell("LongText", CellValues.String),
                    CreateCell("CreatedDate", CellValues.String),
                    CreateCell("OwnerId", CellValues.String),
                    CreateCell("OwnerAlias", CellValues.String),
                    CreateCell("TotalThingsE", CellValues.String));

                sheetData.AppendChild(row);

                foreach (var thingA in thingsA)
                {
                    row = new();

                    row.Append(
                        CreateCell(thingA.Id.CleanNumber(), CellValues.Number),
                        CreateCell(thingA.Name, CellValues.String),
                        CreateCell(thingA.ThingBId!.CleanNumber(), CellValues.Number),
                        CreateCell(thingA.ThingBName, CellValues.String),
                        CreateCell(thingA.ThingCId!.CleanNumber(), CellValues.Number),
                        CreateCell(thingA.ThingCName, CellValues.String),
                        CreateCell(thingA.Text, CellValues.String),
                        CreateCell(thingA.Lookup, CellValues.String),
                        CreateCell(thingA.Money!.CleanNumber(), CellValues.Number),
                        CreateCell(thingA.DateTime.ToDate(), CellValues.String),
                        CreateCell(thingA.Status, CellValues.String),
                        CreateCell(thingA.Integer!.CleanNumber(), CellValues.Number),
                        CreateCell(thingA.Boolean.ToString(), CellValues.String),
                        CreateCell(thingA.LongText, CellValues.String),
                        CreateCell(thingA.CreatedDate.ToDate(), CellValues.String),
                        CreateCell(thingA.OwnerId.CleanNumber(), CellValues.Number),
                        CreateCell(thingA.OwnerAlias, CellValues.String),
                        CreateCell(thingA.TotalThingsE.CleanNumber(), CellValues.Number));


                    sheetData.AppendChild(row);
                }

                worksheetPart.Worksheet.Save();
                document.Close();
            }

            stream.Position = 0;
            return stream.ToArray();
        }

        public byte[] ExportThingsB(List<ThingB> thingsB)
        {
            var stream = new MemoryStream();

            using (var document = SpreadsheetDocument.Create(stream, SpreadsheetDocumentType.Workbook))
            {
                var workbookPart = document.AddWorkbookPart();
                workbookPart.Workbook = new();

                var worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                worksheetPart.Worksheet = new();

                var sheets = workbookPart.Workbook.AppendChild(new Sheets());
                var sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "Sheet1" };
                sheets.Append(sheet);

                workbookPart.Workbook.Save();

                var sheetData = worksheetPart.Worksheet.AppendChild(new SheetData());

                // Constructing header
                var row = new Row();

                row.Append(
                    CreateCell("Id", CellValues.String),
                    CreateCell("Name", CellValues.String),
                    CreateCell("Text", CellValues.String),
                    CreateCell("Lookup", CellValues.String),
                    CreateCell("Money", CellValues.String),
                    CreateCell("DateTime", CellValues.String),
                    CreateCell("Status", CellValues.String),
                    CreateCell("Integer", CellValues.String),
                    CreateCell("Boolean", CellValues.String),
                    CreateCell("LongText", CellValues.String),
                    CreateCell("CreatedDate", CellValues.String),
                    CreateCell("OwnerId", CellValues.String),
                    CreateCell("OwnerAlias", CellValues.String),
                    CreateCell("TotalThingsA", CellValues.String));

                sheetData.AppendChild(row);

                foreach (var thingB in thingsB)
                {
                    row = new();

                    row.Append(
                        CreateCell(thingB.Id.CleanNumber(), CellValues.Number),
                        CreateCell(thingB.Name, CellValues.String),
                        CreateCell(thingB.Text, CellValues.String),
                        CreateCell(thingB.Lookup, CellValues.String),
                        CreateCell(thingB.Money.ToCurrency(), CellValues.String),
                        CreateCell(thingB.DateTime.ToDate(), CellValues.String),
                        CreateCell(thingB.Status, CellValues.String),
                        CreateCell(thingB.Integer!.CleanNumber(), CellValues.Number),
                        CreateCell(thingB.Boolean.ToString(), CellValues.String),
                        CreateCell(thingB.LongText, CellValues.String),
                        CreateCell(thingB.CreatedDate.ToDate(), CellValues.String),
                        CreateCell(thingB.OwnerId.CleanNumber(), CellValues.String),
                        CreateCell(thingB.OwnerAlias, CellValues.String),
                        CreateCell(thingB.TotalThingsA.CleanNumber(), CellValues.Number));


                    sheetData.AppendChild(row);
                }

                worksheetPart.Worksheet.Save();
                document.Close();
            }

            stream.Position = 0;
            return stream.ToArray();
        }

        public byte[] ExportThingsC(List<ThingC> thingsC)
        {
            var stream = new MemoryStream();

            using (var document = SpreadsheetDocument.Create(stream, SpreadsheetDocumentType.Workbook))
            {
                var workbookPart = document.AddWorkbookPart();
                workbookPart.Workbook = new();

                var worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                worksheetPart.Worksheet = new();

                var sheets = workbookPart.Workbook.AppendChild(new Sheets());
                var sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "Sheet1" };
                sheets.Append(sheet);

                workbookPart.Workbook.Save();

                var sheetData = worksheetPart.Worksheet.AppendChild(new SheetData());

                // Constructing header
                var row = new Row();

                row.Append(
                     CreateCell("Id", CellValues.String),
                     CreateCell("Name", CellValues.String),
                     CreateCell("Text", CellValues.String),
                     CreateCell("Lookup", CellValues.String),
                     CreateCell("Money", CellValues.String),
                     CreateCell("DateTime", CellValues.String),
                     CreateCell("Status", CellValues.String),
                     CreateCell("Integer", CellValues.String),
                     CreateCell("Boolean", CellValues.String),
                     CreateCell("LongText", CellValues.String),
                     CreateCell("CreatedDate", CellValues.String),
                     CreateCell("OwnerId", CellValues.String),
                     CreateCell("OwnerAlias", CellValues.String),
                     CreateCell("TotalThingsA", CellValues.String));

                sheetData.AppendChild(row);

                foreach (var thingC in thingsC)
                {
                    row = new();

                    row.Append(
                        CreateCell(thingC.Id.CleanNumber(), CellValues.Number),
                        CreateCell(thingC.Name, CellValues.String),
                        CreateCell(thingC.Text, CellValues.String),
                        CreateCell(thingC.Lookup, CellValues.String),
                        CreateCell(thingC.Money.ToCurrency(), CellValues.String),
                        CreateCell(thingC.DateTime.ToDate(), CellValues.String),
                        CreateCell(thingC.Status, CellValues.String),
                        CreateCell(thingC.Integer!.CleanNumber(), CellValues.Number),
                        CreateCell(thingC.Boolean.ToString(), CellValues.String),
                        CreateCell(thingC.LongText, CellValues.String),
                        CreateCell(thingC.CreatedDate.ToDate(), CellValues.String),
                        CreateCell(thingC.OwnerId.CleanNumber(), CellValues.String),
                        CreateCell(thingC.OwnerAlias, CellValues.String),
                        CreateCell(thingC.TotalThingsA.CleanNumber(), CellValues.Number));


                    sheetData.AppendChild(row);
                }

                worksheetPart.Worksheet.Save();
                document.Close();
            }

            stream.Position = 0;
            return stream.ToArray();
        }

        public byte[] ExportThingsD(List<ThingD> thingsD)
        {
            var stream = new MemoryStream();

            using (var document = SpreadsheetDocument.Create(stream, SpreadsheetDocumentType.Workbook))
            {
                var workbookPart = document.AddWorkbookPart();
                workbookPart.Workbook = new();

                var worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                worksheetPart.Worksheet = new();

                var sheets = workbookPart.Workbook.AppendChild(new Sheets());
                var sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "Sheet1" };
                sheets.Append(sheet);

                workbookPart.Workbook.Save();

                var sheetData = worksheetPart.Worksheet.AppendChild(new SheetData());

                // Constructing header
                var row = new Row();

                row.Append(
                    CreateCell("Id", CellValues.String),
                    CreateCell("Name", CellValues.String),
                    CreateCell("Text", CellValues.String),
                    CreateCell("Lookup", CellValues.String),
                    CreateCell("Money", CellValues.String),
                    CreateCell("DateTime", CellValues.String),
                    CreateCell("Status", CellValues.String),
                    CreateCell("Integer", CellValues.String),
                    CreateCell("Boolean", CellValues.String),
                    CreateCell("LongText", CellValues.String),
                    CreateCell("CreatedDate", CellValues.String),
                    CreateCell("OwnerId", CellValues.String),
                    CreateCell("OwnerAlias", CellValues.String),
                    CreateCell("TotalThingsE", CellValues.String));

                sheetData.AppendChild(row);

                foreach (var thingD in thingsD)
                {
                    row = new();

                    row.Append(
                        CreateCell(thingD.Id.CleanNumber(), CellValues.Number),
                        CreateCell(thingD.Name, CellValues.String),
                        CreateCell(thingD.Text, CellValues.String),
                        CreateCell(thingD.Lookup, CellValues.String),
                        CreateCell(thingD.Money.ToCurrency(), CellValues.String),
                        CreateCell(thingD.DateTime.ToDate(), CellValues.String),
                        CreateCell(thingD.Status, CellValues.String),
                        CreateCell(thingD.Integer!.CleanNumber(), CellValues.Number),
                        CreateCell(thingD.Boolean.ToString(), CellValues.String),
                        CreateCell(thingD.LongText, CellValues.String),
                        CreateCell(thingD.CreatedDate.ToDate(), CellValues.String),
                        CreateCell(thingD.OwnerId.CleanNumber(), CellValues.String),
                        CreateCell(thingD.OwnerAlias, CellValues.String),
                        CreateCell(thingD.TotalThingsE.CleanNumber(), CellValues.Number));

                    sheetData.AppendChild(row);
                }

                worksheetPart.Worksheet.Save();
                document.Close();
            }

            stream.Position = 0;
            return stream.ToArray();
        }

        public byte[] ExportThingsE(List<ThingE> thingsE)
        {
            var stream = new MemoryStream();

            using (var document = SpreadsheetDocument.Create(stream, SpreadsheetDocumentType.Workbook))
            {
                var workbookPart = document.AddWorkbookPart();
                workbookPart.Workbook = new();

                var worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                worksheetPart.Worksheet = new();

                var sheets = workbookPart.Workbook.AppendChild(new Sheets());
                var sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "Sheet1" };
                sheets.Append(sheet);

                workbookPart.Workbook.Save();

                var sheetData = worksheetPart.Worksheet.AppendChild(new SheetData());

                // Constructing header
                var row = new Row();

                row.Append(
                   CreateCell("Id", CellValues.String),
                   CreateCell("Name", CellValues.String),
                   CreateCell("ThingAId", CellValues.String),
                   CreateCell("ThingAName", CellValues.String),
                   CreateCell("ThingDId", CellValues.String),
                   CreateCell("ThingDName", CellValues.String),
                   CreateCell("Text", CellValues.String),
                   CreateCell("Lookup", CellValues.String),
                   CreateCell("Money", CellValues.String),
                   CreateCell("DateTime", CellValues.String),
                   CreateCell("Status", CellValues.String),
                   CreateCell("Integer", CellValues.String),
                   CreateCell("Boolean", CellValues.String),
                   CreateCell("LongText", CellValues.String),
                   CreateCell("CreatedDate", CellValues.String),
                   CreateCell("OwnerId", CellValues.String),
                   CreateCell("OwnerAlias", CellValues.String));

                sheetData.AppendChild(row);

                foreach (var thingE in thingsE)
                {
                    row = new();

                    row.Append(
                        CreateCell(thingE.Id.CleanNumber(), CellValues.Number),
                        CreateCell(thingE.Name, CellValues.String),
                        CreateCell(thingE.ThingAId!.CleanNumber(), CellValues.Number),
                        CreateCell(thingE.ThingAName, CellValues.String),
                        CreateCell(thingE.ThingDId!.CleanNumber(), CellValues.Number),
                        CreateCell(thingE.ThingDName, CellValues.String),
                        CreateCell(thingE.Text, CellValues.String),
                        CreateCell(thingE.Lookup, CellValues.String),
                        CreateCell(thingE.Money!.CleanNumber(), CellValues.Number),
                        CreateCell(thingE.DateTime.ToDate(), CellValues.String),
                        CreateCell(thingE.Status, CellValues.String),
                        CreateCell(thingE.Integer!.CleanNumber(), CellValues.Number),
                        CreateCell(thingE.Boolean.ToString(), CellValues.String),
                        CreateCell(thingE.LongText, CellValues.String),
                        CreateCell(thingE.CreatedDate.ToDate(), CellValues.String),
                        CreateCell(thingE.OwnerId.CleanNumber(), CellValues.Number),
                        CreateCell(thingE.OwnerAlias, CellValues.String));


                    sheetData.AppendChild(row);
                }

                worksheetPart.Worksheet.Save();
                document.Close();
            }

            stream.Position = 0;
            return stream.ToArray();
        }

        public byte[] ExportPeople(List<User> users)
        {
            var stream = new MemoryStream();

            using (var document = SpreadsheetDocument.Create(stream, SpreadsheetDocumentType.Workbook))
            {
                var workbookPart = document.AddWorkbookPart();
                workbookPart.Workbook = new();

                var worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                worksheetPart.Worksheet = new();

                var sheets = workbookPart.Workbook.AppendChild(new Sheets());
                var sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "People" };
                sheets.Append(sheet);

                workbookPart.Workbook.Save();

                var sheetData = worksheetPart.Worksheet.AppendChild(new SheetData());

                // Constructing header
                var row = new Row();

                row.Append(
                    CreateCell("Id", CellValues.String),
                    CreateCell("FirstName", CellValues.String),
                    CreateCell("LastName", CellValues.String),
                    CreateCell("Email", CellValues.String),
                    CreateCell("Alias", CellValues.String),
                    CreateCell("City", CellValues.String),
                    CreateCell("Country", CellValues.String),
                    CreateCell("EmployeeNumber", CellValues.String),
                    CreateCell("Department", CellValues.String),
                    CreateCell("LastLoginDate", CellValues.String),
                    CreateCell("TotalThingsA", CellValues.String),
                    CreateCell("TotalThingsB", CellValues.String),
                    CreateCell("TotalThingsC", CellValues.String),
                    CreateCell("TotalThingsD", CellValues.String),
                    CreateCell("TotalThingsE", CellValues.String),
                    CreateCell("Role", CellValues.String));

                sheetData.AppendChild(row);

                foreach (var user in users)
                {
                    row = new();

                    row.Append(
                        CreateCell(user.Id.CleanNumber(), CellValues.Number),
                        CreateCell(user.FirstName, CellValues.String),
                        CreateCell(user.LastName, CellValues.String),
                        CreateCell(user.Email, CellValues.String),
                        CreateCell(user.Alias, CellValues.String),
                        CreateCell(user.City, CellValues.String),
                        CreateCell(user.Country, CellValues.String),
                        CreateCell(user.EmployeeNumber!.CleanNumber(), CellValues.Number),
                        CreateCell(user.Department, CellValues.String),
                        CreateCell(user.LastLoginDate.ToDateTime(), CellValues.String),
                        CreateCell(user.TotalThingsA.CleanNumber(), CellValues.Number),
                        CreateCell(user.TotalThingsB.CleanNumber(), CellValues.Number),
                        CreateCell(user.TotalThingsC.CleanNumber(), CellValues.Number),
                        CreateCell(user.TotalThingsD.CleanNumber(), CellValues.Number),
                        CreateCell(user.TotalThingsE.CleanNumber(), CellValues.Number),
                        CreateCell(user.Role, CellValues.String));

                    sheetData.AppendChild(row);
                }

                worksheetPart.Worksheet.Save();
                document.Close();
            }

            stream.Position = 0;
            return stream.ToArray();
        }

        #endregion

        #region Import

        public async Task<(string fileName, DataGrid grid)> SaveAsync(IFormFile file)
        {
            var extension = Path.GetExtension(file.FileName);
            if (!extension.Contains("xls")) throw new Exception("Invalid file type. Please use a valid Excel file.");

            try
            {
                var fileName = "Excel-" + Crypto.RandomString(10) + extension;
                var filePath = Qualify(fileName);

                // Save file to temporary Imports folder
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                var grid = ReadToGrid(fileName);

                return (fileName, grid);
            }
            catch (Exception ex)
            {
                var logger = _loggerFactory.CreateLogger<Excel>();
                logger.LogError(0, ex, "Error in Excel.SaveForPreviewAsync.");

                throw new ImportException("Unable to read file. Please use a valid Excel file.", ex);
            }
        }

        public async Task<(int, int)> ImportThingsAAsync(string fileName)
        {
            int count = 0;
            var grid = ReadToGrid(fileName);
            foreach (var row in grid.Rows)
            {
                try
                {
                    var thingA = new ThingA { CreatedOn = DateTime.Now, ChangedOn = DateTime.Now, CreatedDate = DateTime.Now, CreatedBy = _currentUser.Id, OwnerId = _currentUser.Id, OwnerAlias = _cache.Users[_currentUser.Id].Alias };
                    thingA.Name = row["Name"];
                    if (row.ContainsKey("ThingBId") && row["ThingBId"] != null) thingA.ThingBId = int.Parse(row["ThingBId"].ToString());
                    if (row.ContainsKey("ThingBName") && row["ThingBId"] != null) thingA.ThingBName = row["ThingBName"];
                    if (row.ContainsKey("ThingCId") && row["ThingCId"] != null) thingA.ThingCId = int.Parse(row["ThingCId"].ToString());
                    if (row.ContainsKey("ThingCName") && row["ThingCName"] != null) thingA.ThingCName = row["ThingCName"];
                    if (row.ContainsKey("Text") && row["Text"] != null) thingA.Text = row["Text"];
                    if (row.ContainsKey("Lookup") && row["Lookup"] != null) thingA.Lookup = row["Lookup"];
                    if (row.ContainsKey("Money") && row["Money"] != null) thingA.Money = decimal.Parse(row["Money"].ToString());
                    if (row.ContainsKey("DateTime") && row["DateTime"] != null) thingA.DateTime = DateTime.Parse(row["DateTime"].ToString());
                    if (row.ContainsKey("Integer") && row["Integer"] != null) thingA.Integer = int.Parse(row["Integer"]);
                    if (row.ContainsKey("Boolean") && row["Boolean"] != null) thingA.Boolean = bool.Parse(row["Boolean"].ToString());
                    if (row.ContainsKey("Status") && row["Status"] != null) thingA.Status = row["Status"];
                    if (row.ContainsKey("LongText") && row["LongText"] != null) thingA.LongText = row["LongText"];

                    _db.ThingAs.Add(thingA);
                    await _db.SaveChangesAsync();

                    count++;
                }
                catch
                {
                    // No logging here. Just one import row less (for now)
                }
            }

            // temp file can be deleted

            var filePath = Qualify(fileName);
            File.Delete(filePath);

            if (count == 0) throw new ImportException("No records were loaded. Please try again", null);

            return (count, grid.Rows.Count);
        }

        public async Task<(int, int)> ImportThingsBAsync(string fileName)
        {
            int count = 0;
            var grid = ReadToGrid(fileName);
            foreach (var row in grid.Rows)
            {
                try
                {
                    var thingB = new ThingB { CreatedOn = DateTime.Now, ChangedOn = DateTime.Now, CreatedDate = DateTime.Now, CreatedBy = _currentUser.Id, OwnerId = _currentUser.Id, OwnerAlias = _cache.Users[_currentUser.Id].Alias };
                    thingB.Name = row["Name"];
                    if (row.ContainsKey("Text") && row["Text"] != null) thingB.Text = row["Text"];
                    if (row.ContainsKey("Lookup") && row["Lookup"] != null) thingB.Lookup = row["Lookup"];
                    if (row.ContainsKey("Money") && row["Money"] != null) thingB.Money = decimal.Parse(row["Money"].ToString());
                    if (row.ContainsKey("DateTime") && row["DateTime"] != null) thingB.DateTime = DateTime.Parse(row["DateTime"].ToString());
                    if (row.ContainsKey("Status") && row["Status"] != null) thingB.Status = row["Status"];
                    if (row.ContainsKey("Integer") && row["Integer"] != null) thingB.Integer = int.Parse(row["Integer"]);
                    if (row.ContainsKey("Boolean") && row["Boolean"] != null) thingB.Boolean = bool.Parse(row["Boolean"].ToString());
                    if (row.ContainsKey("LongText") && row["LongText"] != null) thingB.LongText = row["LongText"];

                    _db.ThingBs.Add(thingB);
                    await _db.SaveChangesAsync();

                    count++;
                }
                catch
                {
                    // No logging here. Just one import row less (for now)
                }
            }

            // temp file can be deleted

            var filePath = Qualify(fileName);
            File.Delete(filePath);

            if (count == 0) throw new ImportException("No records were loaded. Please try again", null);

            return (count, grid.Rows.Count);
        }

        public async Task<(int, int)> ImportThingsCAsync(string fileName)
        {
            int count = 0;
            var grid = ReadToGrid(fileName);
            foreach (var row in grid.Rows)
            {
                try
                {
                    var thingC = new ThingC { CreatedOn = DateTime.Now, ChangedOn = DateTime.Now, CreatedDate = DateTime.Now, CreatedBy = _currentUser.Id, OwnerId = _currentUser.Id, OwnerAlias = _cache.Users[_currentUser.Id].Alias };
                    thingC.Name = row["Name"];
                    if (row.ContainsKey("Text") && row["Text"] != null) thingC.Text = row["Text"];
                    if (row.ContainsKey("Lookup") && row["Lookup"] != null) thingC.Lookup = row["Lookup"];
                    if (row.ContainsKey("Money") && row["Money"] != null) thingC.Money = decimal.Parse(row["Money"].ToString());
                    if (row.ContainsKey("DateTime") && row["DateTime"] != null) thingC.DateTime = DateTime.Parse(row["DateTime"].ToString());
                    if (row.ContainsKey("Status") && row["Status"] != null) thingC.Status = row["Status"];
                    if (row.ContainsKey("Integer") && row["Integer"] != null) thingC.Integer = int.Parse(row["Integer"]);
                    if (row.ContainsKey("Boolean") && row["Boolean"] != null) thingC.Boolean = bool.Parse(row["Boolean"].ToString());
                    if (row.ContainsKey("LongText") && row["LongText"] != null) thingC.LongText = row["LongText"];

                    _db.ThingCs.Add(thingC);
                    await _db.SaveChangesAsync();

                    count++;
                }
                catch
                {
                    // No logging here. Just one import row less (for now)
                }
            }

            // temp file can be deleted

            var filePath = Qualify(fileName);
            File.Delete(filePath);

            if (count == 0) throw new ImportException("No records were loaded. Please try again", null);

            return (count, grid.Rows.Count);
        }

        public async Task<(int, int)> ImportThingsDAsync(string fileName)
        {
            int count = 0;
            var grid = ReadToGrid(fileName);
            foreach (var row in grid.Rows)
            {
                try
                {
                    var thingD = new ThingD { CreatedOn = DateTime.Now, ChangedOn = DateTime.Now, CreatedDate = DateTime.Now, CreatedBy = _currentUser.Id, OwnerId = _currentUser.Id, OwnerAlias = _cache.Users[_currentUser.Id].Alias };
                    thingD.Name = row["Name"];
                    if (row.ContainsKey("Text") && row["Text"] != null) thingD.Text = row["Text"];
                    if (row.ContainsKey("Lookup") && row["Lookup"] != null) thingD.Lookup = row["Lookup"];
                    if (row.ContainsKey("Money") && row["Money"] != null) thingD.Money = decimal.Parse(row["Money"].ToString());
                    if (row.ContainsKey("DateTime") && row["DateTime"] != null) thingD.DateTime = DateTime.Parse(row["DateTime"].ToString());
                    if (row.ContainsKey("Status") && row["Status"] != null) thingD.Status = row["Status"];
                    if (row.ContainsKey("Integer") && row["Integer"] != null) thingD.Integer = int.Parse(row["Integer"]);
                    if (row.ContainsKey("Boolean") && row["Boolean"] != null) thingD.Boolean = bool.Parse(row["Boolean"].ToString());
                    if (row.ContainsKey("LongText") && row["LongText"] != null) thingD.LongText = row["LongText"];

                    _db.ThingDs.Add(thingD);
                    await _db.SaveChangesAsync();

                    count++;
                }
                catch
                {
                    // No logging here. Just one import row less (for now)
                }
            }

            // temp file can be deleted

            var filePath = Qualify(fileName);
            File.Delete(filePath);

            if (count == 0) throw new ImportException("No records were loaded. Please try again", null);

            return (count, grid.Rows.Count);
        }

        public async Task<(int, int)> ImportThingsEAsync(string fileName)
        {
            int count = 0;
            var grid = ReadToGrid(fileName);
            foreach (var row in grid.Rows)
            {
                try
                {
                    var thingE = new ThingE { CreatedOn = DateTime.Now, ChangedOn = DateTime.Now, CreatedDate = DateTime.Now, CreatedBy = _currentUser.Id, OwnerId = _currentUser.Id, OwnerAlias = _cache.Users[_currentUser.Id].Alias };
                    thingE.Name = row["Name"];
                    if (row.ContainsKey("ThingAId") && row["ThingAId"] != null) thingE.ThingAId = int.Parse(row["ThingAId"].ToString());
                    if (row.ContainsKey("ThingAName") && row["ThingAName"] != null) thingE.ThingAName = row["ThingAName"];
                    if (row.ContainsKey("ThingDId") && row["ThingDId"] != null) thingE.ThingDId = int.Parse(row["ThingDId"].ToString());
                    if (row.ContainsKey("ThingDName") && row["ThingDName"] != null) thingE.ThingDName = row["ThingDName"];
                    if (row.ContainsKey("Text") && row["Text"] != null) thingE.Text = row["Text"];
                    if (row.ContainsKey("Lookup") && row["Lookup"] != null) thingE.Lookup = row["Lookup"];
                    if (row.ContainsKey("Money") && row["Money"] != null) thingE.Money = decimal.Parse(row["Money"].ToString());
                    if (row.ContainsKey("DateTime") && row["DateTime"] != null) thingE.DateTime = DateTime.Parse(row["DateTime"].ToString());
                    if (row.ContainsKey("Integer") && row["Integer"] != null) thingE.Integer = int.Parse(row["Integer"]);
                    if (row.ContainsKey("Boolean") && row["Boolean"] != null) thingE.Boolean = bool.Parse(row["Boolean"].ToString());
                    if (row.ContainsKey("Status") && row["Status"] != null) thingE.Status = row["Status"];
                    if (row.ContainsKey("LongText") && row["LongText"] != null) thingE.LongText = row["LongText"];

                    _db.ThingEs.Add(thingE);
                    await _db.SaveChangesAsync();

                    count++;
                }
                catch
                {
                    // No logging here. Just one import row less (for now)
                }
            }

            // temp file can be deleted

            var filePath = Qualify(fileName);
            File.Delete(filePath);

            if (count == 0) throw new ImportException("No records were loaded. Please try again", null);

            return (count, grid.Rows.Count);
        }


        #endregion

        #region Helpers

        private DataGrid ReadToGrid(string fileName)
        {
            var grid = new DataGrid();

            var filePath = Qualify(fileName);

            var document = SpreadsheetDocument.Open(filePath, false);
            var sharedStringTable = document.WorkbookPart!.SharedStringTablePart!.SharedStringTable;
            string value;

            bool isheader = true;
            foreach (var worksheetPart in document.WorkbookPart.WorksheetParts)
            {
                foreach (var sheetData in worksheetPart.Worksheet.Elements<SheetData>())
                {
                    if (sheetData.HasChildren)
                    {
                        foreach (var row in sheetData.Elements<Row>())
                        {
                            int columnIndex = 0;
                            var dictionary = new Dictionary<string, string>();

                            foreach (var cell in row.Elements<Cell>())
                            {
                                value = cell.InnerText;

                                if (value != null && cell.DataType != null && cell.DataType == CellValues.SharedString)
                                    value = sharedStringTable.ElementAt(int.Parse(value)).InnerText;

                                if (isheader)
                                {
                                    grid.Headers.Add(value ?? "");
                                }
                                else
                                {
                                    var header = grid.Headers[columnIndex];
                                    dictionary.Add(header, value ?? "");
                                }

                                columnIndex++;
                            }

                            if (!isheader)
                                grid.Rows.Add(dictionary);

                            isheader = false;
                        }
                    }
                }
            }

            document.Close();

            return grid;
        }

        private static Cell CreateCell(string? value, CellValues dataType)
        {
            return new Cell()
            { 
                CellValue = value == null ? null : new CellValue(value),
                DataType = new EnumValue<CellValues>(dataType)
            };
        }

        #endregion
    }
}
