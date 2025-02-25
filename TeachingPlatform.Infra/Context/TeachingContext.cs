using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TeachingPlatform.Domain.Models;

namespace TeachingPlatform.Infra.Context
{
    public class TeachingContext(DbContextOptions<TeachingContext> options) : IdentityDbContext<User, IdentityRole<Guid>, Guid>(options)
    {
        public DbSet<Lesson> Lesson { get; set; } = null!;
        public DbSet<Domain.Models.Module> Module { get; set; } = null!;
        public DbSet<Course> Course { get; set; } = null!;
        public DbSet<Enrollment> Enrollment { get; set; } = null!;

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
