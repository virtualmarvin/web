namespace Marvin.Web.Areas.Home
{
    public record _ThingA
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? ThingBId { get; set; }
        public string? ThingBName { get; set; }

        public string? Money { get; set; }
        public string? DateTime { get; set; }
    }
}

