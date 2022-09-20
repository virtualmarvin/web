using System.ComponentModel.DataAnnotations.Schema;

namespace Marvin.Web.Domain
{
    [Table("ThingD")]
    public partial class ThingD : IAuditable
    {
        public ThingD()
        {
            ThingEs = new HashSet<ThingE>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Text { get; set; }
        public string? Lookup { get; set; }
        public decimal? Money { get; set; }
        public DateTime? DateTime { get; set; }
        public string? Status { get; set; }
        public int? Integer { get; set; }
        public bool? Boolean { get; set; }
        public string? LongText { get; set; }
        public int TotalThingsE { get; set; }
        public int OwnerId { get; set; }
        public string OwnerAlias { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime ChangedOn { get; set; }
        public int? ChangedBy { get; set; }

        public virtual User Owner { get; set; } = null!;
        public virtual ICollection<ThingE> ThingEs { get; set; }
    }
}
