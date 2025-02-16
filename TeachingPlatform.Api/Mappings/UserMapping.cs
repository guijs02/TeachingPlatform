using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeachingPlatform.Domain.Models;

namespace TeachingPlatform.Api.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasMany(s => s.Enrollments)
                .WithOne(s => s.Student)
                .HasForeignKey(s => s.StudentId)
                .OnDelete(DeleteBehavior.Restrict);
            
            builder.Property(u => u.Id)
                   .ValueGeneratedOnAdd();
        }
    }
}
