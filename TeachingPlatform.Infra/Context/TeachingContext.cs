using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Reflection;
using TeachingPlatform.Infra.Models;
using TeachingPlatform.Domain.ValueObjects;
using System.Linq.Expressions;

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
            // Aplicar configurações (mappings) padrão
            builder.ApplyConfigurationsFromAssembly(Assembly.GetCallingAssembly());

            // Conversores para ValueObjects -> Guid
            var courseIdConverter = new ValueConverter<CourseId, Guid>(
                v => v.Value,
                v => new CourseId(v));

            // Se houver StudentId como VO, converter também
            // Assumo que existe TeachingPlatform.Domain.ValueObjects.StudentId
            Type? studentIdType = Type.GetType("TeachingPlatform.Domain.ValueObjects.StudentId");
            ValueConverter? studentIdConverter = null;
            if (studentIdType is not null)
            {
                // Constrói dinamicamente apenas se o tipo existir para evitar erros de compilação em ambientes diferentes
                studentIdConverter = (ValueConverter)Activator.CreateInstance(
                    typeof(ValueConverter<,>).MakeGenericType(studentIdType, typeof(Guid)),
                    new object []
                    {
                        (Expression<Func<object, Guid>>)(o => ((Guid)o)),
                        (Expression<Func<Guid, object>>)(g => Activator.CreateInstance(studentIdType, g)!)
                    })!;
            }

            // Aplicar conversores globais nas propriedades que usam esses VOs
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                var properties = entityType.GetProperties();

                foreach (var prop in properties)
                {
                    if (prop.ClrType == typeof(CourseId))
                        prop.SetValueConverter(courseIdConverter);

                    if (studentIdConverter is not null && prop.ClrType.FullName == studentIdType!.FullName)
                        prop.SetValueConverter(studentIdConverter);
                }
            }

            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }

}
