using TeachingPlatform.Domain.Entities;
using TeachingPlatform.Domain.Interfaces;
using TeachingPlatform.Infra.Context;
using TeachingPlatform.Infra.Mapping;

namespace TeachingPlatform.Infra.Repositories
{
    public class CourseRepository(TeachingContext context) : ICourseRepository
    {
        private readonly TeachingContext _context = context;
        public async Task<Course> Create(Course course)
        {
            try
            {

                var model = course.ToModel();

                _context.Course.Add(model);

                await _context.SaveChangesAsync();

                return course;
            }
            catch (Exception e)
            {

                throw;
            }

        }
    }
}
