using System.ComponentModel.DataAnnotations.Schema;

namespace Marvin.Web.Domain
{
    [Table("User")]
    public partial class User : IAuditable
    {
        public User()
        {
            Errors = new HashSet<Error>();
            Logins = new HashSet<Login>();
            ThingAs = new HashSet<ThingA>();
            ThingBs = new HashSet<ThingB>();
            ThingCs = new HashSet<ThingC>();
            ThingDs = new HashSet<ThingD>();
            ThingEs = new HashSet<ThingE>();
            Vieweds = new HashSet<Viewed>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Alias { get; set; } = null!;
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? EmployeeNumber { get; set; }
        public string? Department { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public int TotalThingsA { get; set; }
        public int TotalThingsB { get; set; }
        public int TotalThingsC { get; set; }
        public int TotalThingsD { get; set; }
        public int TotalThingsE { get; set; }
        public string Role { get; set; } = null!;
        public string? IdentityId { get; set; }
        public string? IdentityName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? ActivationCode { get; set; }
        public DateTime? ActivationDate { get; set; }
        public string? ResetCode { get; set; }
        public DateTime? ResetDate { get; set; }
        public string? AppKey { get; set; }
        public string? AppSecret { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime ChangedOn { get; set; }
        public int? ChangedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
        public int? DeletedBy { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<Error> Errors { get; set; }
        public virtual ICollection<Login> Logins { get; set; }
        public virtual ICollection<ThingA> ThingAs { get; set; }
        public virtual ICollection<ThingB> ThingBs { get; set; }
        public virtual ICollection<ThingC> ThingCs { get; set; }
        public virtual ICollection<ThingD> ThingDs { get; set; }
        public virtual ICollection<ThingE> ThingEs { get; set; }
        public virtual ICollection<Viewed> Vieweds { get; set; }
    }
}
