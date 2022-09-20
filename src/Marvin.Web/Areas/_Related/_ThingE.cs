namespace Marvin.Web.Areas._Related
{
    public record _ThingsE 
    {
        public int TotalThingsE { get; set; }
        public List<_ThingE> ThingsE { get; set; } = new();
        public int ParentId { get; set; }
        public string? ParentIdName { get; set; }
        public string? ParentName { get; set; }
    }

    public record _ThingE
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Lookup { get; set; }
        public string? Money { get; set; }
        public string? Date { get; set; }
    }
}
