using efcore_navigation.Data.StoredProcedure;
using Microsoft.EntityFrameworkCore;

namespace efcore_navigation.Data
{
    public class SampledbContext: DbContext
    {

        public SampledbContext(DbContextOptions<SampledbContext> context)
            :base(context)
        {
            
        }

        public override int SaveChanges()
        {
            ApplyAuditInfo();

            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            ApplyAuditInfo();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SampledbContext).Assembly);

            modelBuilder.Entity<FetchEmployeesByDepartment>().HasNoKey().ToView(null);
            modelBuilder.Entity<GetTopProductResult>().HasNoKey().ToView(null);

            base.OnModelCreating(modelBuilder);
        }


        private void ApplyAuditInfo()
        {
            var entries = ChangeTracker.Entries()
                .Where(x => x.Entity is AuditEntity &&
                 (x.State == EntityState.Added || x.State == EntityState.Modified));


            foreach (var entry in entries)
            {

                var entity = (AuditEntity)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    entity.CreatedBy = "system";
                    entity.CreatedDate = DateTime.UtcNow;
                }

                if (entry.State == EntityState.Modified)
                {
                    entity.ModifiedBy = "system";
                    entity.ModifiedDate = DateTime.UtcNow;
                }
            }
        }

        public DbSet<User> Users { get; set; } = default!;  
        public DbSet<Department> Departments { get; set; } = default!;
        public DbSet<FetchEmployeesByDepartment> FetchEmployeesByDepartments { get; set; } = default!;  
        public DbSet<Product> Products { get; set; }
    }
}