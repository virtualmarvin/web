namespace Marvin.Web.Areas._Related
{
    public record _ThingsD 
    {
        public int TotalThingsD { get; set; }
        public List<_ThingD> ThingsD { get; set; } = new();
        public int ParentId { get; set; }
        public string? ParentIdName { get; set; }
        public string? ParentName { get; set; }
    }

    public record _ThingD
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Integer { get; set; }
        public string? Status { get; set; }
        public string? Lookup { get; set; }
        public int TotalThingsE { get; set; }

    }
}
