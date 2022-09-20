using System.ComponentModel.DataAnnotations.Schema;

namespace Marvin.Web.Domain
{
    [Table("ThingE")]
    public partial class ThingE : IAuditable
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? ThingAId { get; set; }
        public string? ThingAName { get; set; }
        public int? ThingDId { get; set; }
        public string? ThingDName { get; set; }
        public string? Text { get; set; }
        public string? Lookup { get; set; }
        public decimal? Money { get; set; }
        public DateTime? DateTime { get; set; }
        public string? Status { get; set; }
        public int? Integer { get; set; }
        public bool? Boolean { get; set; }
        public string? LongText { get; set; }
        public int OwnerId { get; set; }
        public string OwnerAlias { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime ChangedOn { get; set; }
        public int? ChangedBy { get; set; }

        public virtual User Owner { get; set; } = null!;
        public virtual ThingA? ThingA { get; set; }
        public virtual ThingD? ThingD { get; set; }
    }
}
