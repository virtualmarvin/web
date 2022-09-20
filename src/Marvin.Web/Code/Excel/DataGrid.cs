namespace Marvin.Web
{
    // Intermediary between entities and excel rows

    public class DataGrid
    {
        public List<string> Headers { get; } = new();
        public Dictionary<string, string> Types { get; } = new();
        public List<Dictionary<string, string>> Rows { get; } = new();
    }
}
