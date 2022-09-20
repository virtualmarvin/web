namespace Marvin.Web.Areas._Related
{
    public record _ThingsA 
    {
        public int TotalThingsA { get; set; }
        public List<_ThingA> ThingsA { get; set; } = new();
        public int ParentId { get; set; }
        public string? ParentIdName { get; set; }
        public string? ParentName { get; set; }
    }

    public record _ThingA
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Lookup { get; set; }
        public string? Status { get; set; }
        public int? Integer { get; set; }
        public int TotalThingsE { get; set; }
    }
}
