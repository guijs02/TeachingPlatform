using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TeachingPlatform.Domain.Models;

namespace TeachingPlatform.Infra.Context
{
    public class TeachingContext(DbContextOptions<TeachingContext> options) : IdentityDbContext<User>(options)
    {
        public DbSet<Lesson> Lesson { get; set; } = null!;
        public DbSet<Module> Module { get; set; } = null!;
        public DbSet<Rating> Rating { get; set; } = null!;
        public DbSet<Student> Student { get; set; } = null!;
        public DbSet<Teacher> Teacher { get; set; } = null!;
        public DbSet<Course> Course { get; set; } = null!;

    }
}
