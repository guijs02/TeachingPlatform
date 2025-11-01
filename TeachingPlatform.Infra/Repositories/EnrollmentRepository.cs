using Microsoft.EntityFrameworkCore;
using TeachingPlatform.Application;
using TeachingPlatform.Domain.Entities;
using TeachingPlatform.Domain.Interfaces;
using TeachingPlatform.Domain.Repositories;
using TeachingPlatform.Infra.Context;
using TeachingPlatform.Infra.Mapping;

namespace TeachingPlatform.Infra.Repositories
{
    public class EnrollmentRepository(TeachingContext context) : IEnrollmentRepository
    {
        public async Task<Guid> Create(Enrollment enrollment)
        {
            try
            {
                // Usar o Guid interno do Value Object antes de enviar para EF/Npgsql
                var existCourse = await context.Course
                        .AsNoTracking()
                        .AnyAsync(a => a.Id == enrollment.CourseId.Value);
                
                var isEnrolment = await context.Enrollment
                        .AsNoTracking()
                        .AnyAsync(a => a.CourseId == enrollment.CourseId.Value && a.StudentId == enrollment.StudentId.Value);


                if (!existCourse)
                    return Guid.Empty;
                
                if (isEnrolment)
                    return Guid.Empty;

                var model = enrollment.ToModel();
                context.Enrollment.Add(model);
                await context.SaveChangesAsync();

                return enrollment.CourseId.Value;
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public async Task<string> GetNameByCourseStudentAsync(Guid courseId, Guid studentId)
        {
            var courseName = await context.Enrollment
                            .Where(e => e.CourseId == courseId && e.StudentId == studentId)
                            .Select(s => s.Course.Name)
                            .FirstOrDefaultAsync();

            return courseName;

        }
    }
}
