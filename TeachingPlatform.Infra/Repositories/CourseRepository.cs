using Microsoft.EntityFrameworkCore;
using TeachingPlatform.Domain.Entities;
using TeachingPlatform.Domain.Repositories;
using TeachingPlatform.Domain.Responses;
using TeachingPlatform.Infra.Context;
using TeachingPlatform.Infra.Mapping;

namespace TeachingPlatform.Infra.Repositories
{
    public class CourseRepository(TeachingContext context) : ICourseRepository
    {
        private readonly TeachingContext _context = context;
        public async Task<Course> CreateAsync(Course course)
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

        public async Task<List<CourseGetAllResponse>> GetAllCourses(int pageSize, int pageNumber, Guid userId)
        {

            var courses = await _context.Course
                       .Where(c => c.TeacherId == userId)
                       .Skip((pageNumber - 1) * pageSize)
                       .Take(pageSize)
                       .Select(c => new CourseGetAllResponse(c.Name, c.Description))
                       .ToListAsync();

            return courses;

        }
        public async Task<GetAllContentCourseResponse?> GetAllContentCourseAsync(Guid courseId, Guid userId)
        {
            var query = _context.Course
                .AsNoTracking()
                .Where(c => c.TeacherId == userId && c.Id == courseId)
                .Include(c => c.Modules)
                .ThenInclude(m => m.Lessons);

            return await query.Select(c => new GetAllContentCourseResponse(
                c.Name,
                c.Modules.Select(m => new CourseModuleResponse(
                    m.Id,
                    m.Name,
                    m.Lessons.Select(l => new CourseLessonResponse(l.Name, l.Id))
                ))
            )).FirstOrDefaultAsync();
        }

        //public async Task<Course> GetLessonByModuleCourse()
        //{
        //    var input = new
        //    {
        //        CourseId = Guid.NewGuid(),
        //        UserId = Guid.NewGuid(),
        //        ModuleId = Guid.NewGuid(),
        //        LessonId = Guid.NewGuid()
        //    };

        //    var query = _context.Course
        //        .Where(c => c.Id == input.CourseId && c.TeacherId == input.UserId &&
        //                c.Modules.Any(m => m.Id == input.ModuleId && m.Lessons.Any(l => l.Id == input.LessonId)))
        //        .Include(c => c.Modules)
        //        .ThenInclude(m => m.Lessons)
        //        .FirstOrDefault();


        //    return query?.ToEntity();


        //}
    }
}
