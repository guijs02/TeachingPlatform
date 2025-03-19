using Microsoft.EntityFrameworkCore;
using TeachingPlatform.Domain.Entities;
using TeachingPlatform.Domain.Interfaces;
using TeachingPlatform.Infra.Context;
using TeachingPlatform.Infra.Mapping;

namespace TeachingPlatform.Infra.Repositories
{
    public class EnrollmentRepository(TeachingContext context) : IEnrollmentRepository
    {
        public async Task<Enrollment?> Create(Enrollment enrollment)
        {
            var model = enrollment.ToModel();
            context.Enrollment.Add(model);
            await context.SaveChangesAsync();

            return context.Enrollment
                                     .Include(i => i.Course)
                                     .Include(i => i.Student)
                                     ?.FirstOrDefault()
                                     ?.ToEntity();

        }
    }
}
