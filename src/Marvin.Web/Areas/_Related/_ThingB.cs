namespace Marvin.Web.Areas._Related
{
    public record _ThingsB 
    {
        public int TotalThingsB { get; set; }
        public List<_ThingB> ThingsB { get; set; } = new();
        public int ParentId { get; set; }
        public string? ParentIdName { get; set; }
        public string? ParentName { get; set; }
    }

    public record _ThingB
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Lookup { get; set; }
        public string? Money { get; set; }
        public string? Status { get; set; }
        public int TotalThingsA { get; set; }

    }
}
