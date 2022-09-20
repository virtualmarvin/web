using System.ComponentModel.DataAnnotations.Schema;

namespace Marvin.Web.Domain
{
    [Table("Viewed")]
    public partial class Viewed : IAuditable
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int WhatId { get; set; }
        public string WhatType { get; set; } = null!;
        public string? WhatName { get; set; }
        public DateTime ViewDate { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime ChangedOn { get; set; }
        public int? ChangedBy { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
