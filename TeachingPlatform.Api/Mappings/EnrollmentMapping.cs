using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeachingPlatform.Infra.Models;

namespace TeachingPlatform.Api.Mappings
{
    public class EnrollmentMapping : IEntityTypeConfiguration<EnrollmentModel>
    {
        public void Configure(EntityTypeBuilder<EnrollmentModel> builder)
        {
            builder.HasOne(s => s.Course)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(s => s.CourseId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(e => e.Student)
                .WithMany(u => u.Enrollments)
                .HasForeignKey(e => e.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
