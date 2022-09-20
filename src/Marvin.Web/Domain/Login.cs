using System.ComponentModel.DataAnnotations.Schema;

namespace Marvin.Web.Domain
{
    [Table("login")]
    public partial class Login : IAuditable
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public string Email { get; set; } = null!;
        public DateTime LoginDate { get; set; }
        public string Result { get; set; } = null!;
        public string? IpAddress { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime ChangedOn { get; set; }
        public int? ChangedBy { get; set; }

        public virtual User? User { get; set; }
    }
}
