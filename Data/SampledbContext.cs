using Microsoft.EntityFrameworkCore;

namespace efcore_navigation.Data
{
    public class SampledbContext: DbContext
    {

        public SampledbContext(DbContextOptions<SampledbContext> context)
            :base(context)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SampledbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; } = default!;  

        public DbSet<UserProfile> UserProfiles { get; set; } = default!;

        public DbSet<Department> Departments { get; set; } = default!;
    }
}
