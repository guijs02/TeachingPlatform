using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TeachingPlatform.Infra.Models;

namespace TeachingPlatform.Infra.Context
{
    public class TeachingContext(DbContextOptions<TeachingContext> options) 
                                    : IdentityDbContext<UserModel, IdentityRole<Guid>, Guid>(options)
    {
        public DbSet<LessonModel> Lesson { get; set; } = null!;
        public DbSet<ModuleModel> Module { get; set; } = null!;
        public DbSet<CourseModel> Course { get; set; } = null!;
        public DbSet<EnrollmentModel> Enrollment { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetCallingAssembly());
            base.OnModelCreating(builder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }

}
