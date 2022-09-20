namespace Marvin.Web.Areas._Related
{
    public record _ThingsC 
    {
        public int TotalThingsC { get; set; }
        public List<_ThingC> ThingsC { get; set; } = new();
        public int ParentId { get; set; }
        public string? ParentIdName { get; set; }
        public string? ParentName { get; set; }
    }

    public record _ThingC
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool? Boolean { get; set; }
        public string? Status { get; set; }
        public string? Money { get; set; }
        public int TotalThingsA { get; set; }

    }
}
