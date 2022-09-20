using Microsoft.EntityFrameworkCore;

namespace Marvin.Web.Domain
{
    public partial class UltraContext : DbContext
    {
        public UltraContext() { }

        public UltraContext(DbContextOptions<UltraContext> options) : base(options) { }

        public virtual DbSet<Error> Errors => Set<Error>();
        public virtual DbSet<Login> Logins => Set<Login>();
        public virtual DbSet<ThingA> ThingAs => Set<ThingA>();
        public virtual DbSet<ThingB> ThingBs => Set<ThingB>();
        public virtual DbSet<ThingC> ThingCs => Set<ThingC>();
        public virtual DbSet<ThingD> ThingDs => Set<ThingD>();
        public virtual DbSet<ThingE> ThingEs => Set<ThingE>();
        public virtual DbSet<User> Users => Set<User>();
        public virtual DbSet<Viewed> Vieweds => Set<Viewed>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // This prevents EF Core from silently truncating decimal values

            modelBuilder.Entity<ThingA>()
              .Property(p => p.Money)
              .HasColumnType("decimal(16,2)");

            modelBuilder.Entity<ThingB>()
              .Property(p => p.Money)
              .HasColumnType("decimal(16,2)");

            modelBuilder.Entity<ThingC>()
              .Property(p => p.Money)
              .HasColumnType("decimal(16,2)");

            modelBuilder.Entity<ThingD>()
              .Property(p => p.Money)
              .HasColumnType("decimal(16,2)");

            modelBuilder.Entity<ThingE>()
              .Property(p => p.Money)
              .HasColumnType("decimal(16,2)");
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var currentUser = ServiceLocator.Resolve<ICurrentUser>();

            // Automatically updates the audit fields with each INSERT or UPDATE

            foreach (var entry in ChangeTracker.Entries<IAuditable>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = entry.Entity.ChangedBy = currentUser.Id;
                        entry.Entity.CreatedOn = entry.Entity.ChangedOn = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        entry.Entity.ChangedBy = currentUser.Id;
                        entry.Entity.ChangedOn = DateTime.UtcNow;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
