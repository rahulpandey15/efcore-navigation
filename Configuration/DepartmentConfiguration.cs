using efcore_navigation.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace efcore_navigation.Configuration
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasMany(x => x.Users)
                   .WithOne(x => x.Department)
                   .HasForeignKey(x => x.DepartmentId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
