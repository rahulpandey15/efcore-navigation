using efcore_navigation.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace efcore_navigation.Configuration
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasMany(x => x.Courses)
                .WithMany(x => x.Students)
                .UsingEntity<Dictionary<string, object>>(
                    "StudentCourse",
                    j => j
                        .HasOne<Courses>()
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .HasConstraintName("FK_StudentCourse_Courses_CourseId")
                        .OnDelete(DeleteBehavior.Cascade),
                    j => j
                        .HasOne<Student>()
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .HasConstraintName("FK_StudentCourse_Students_StudentId")
                        .OnDelete(DeleteBehavior.ClientCascade));
        }
    }
}
