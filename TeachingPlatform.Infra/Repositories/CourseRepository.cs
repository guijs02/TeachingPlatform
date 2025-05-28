using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using TeachingPlatform.Domain.Entities;
using TeachingPlatform.Domain.Repositories;
using TeachingPlatform.Domain.Responses;
using TeachingPlatform.Infra.Context;
using TeachingPlatform.Infra.Mapping;
using TeachingPlatform.Infra.Models;

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

            return await _context.Course
                       .Where(c => c.TeacherId == userId || c.Enrollments.Any(a => a.StudentId == userId))
                       .Skip((pageNumber - 1) * pageSize)
                       .Take(pageSize)
                       .Select(c => new CourseGetAllResponse(c.Id, c.Name, c.Description, c.Progress))
                       .ToListAsync();

        }
        public async Task<GetAllContentCourseResponse?> GetAllContentCourseAsync(Guid courseId, Guid userId)
        {
            var query = _context.Course
                .AsNoTracking()
                .Where(c => (c.TeacherId == userId || 
                        c.Enrollments.Any(a => a.StudentId == userId)) 
                        && c.Id == courseId)
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

        public async Task<bool> FinishLessonAsync(Guid courseId, Guid moduleId, Guid lessonId, Guid studentId)
        {
            try
            {

                var lesson = await GetLessonsByModuleCourse(courseId, moduleId, lessonId);

                if (lesson is not null)
                {
                    lesson.IsCompleted = true;

                    await _context.SaveChangesAsync();

                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<bool> ChangeProgressAsync(Course course)
        {
            try
            {
                var model = await _context.Course.FindAsync(course.Id);

                if (model is null)
                    return false;

                model.Progress = $"{Math.Round(course.Progress, 2)}%";

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        private async Task<LessonModel?> GetLessonsByModuleCourse(Guid courseId, Guid moduleId, Guid lessonId)
        {
            return await _context.Course
                     .Where(c => c.Id == courseId && c.Modules.Any(m => m.Id == moduleId))
                     .Select(s => s.Modules
                         .SelectMany(m => m.Lessons)
                         .FirstOrDefault(l => l.Id == lessonId))
                     .FirstOrDefaultAsync();
        }

        public async Task<Course?> GetCourseWithLessonCompleted(Guid courseId, Guid userId, Guid moduleId, Guid lessonId)
        {
            var query = await _context.Course
                .AsNoTracking()
                .Where(c => c.Enrollments.Any(e => e.CourseId == courseId && e.StudentId == userId) &&
                        c.Modules.Any(m => m.Id == moduleId &&
                        m.Lessons.Any(l => l.Id == lessonId && l.IsCompleted)))
                .Include(i => i.Modules)
                .ThenInclude(i => i.Lessons)
                .FirstOrDefaultAsync();

            return query?.ToEntity();
        }

        public async Task<bool> VerifyEnrollmentStudentActive(Guid courseId, Guid studentId)
        {
            return await _context.Enrollment
                .AsNoTracking()
                .AnyAsync(e => e.CourseId == courseId && e.StudentId == studentId);

        }
    }
}
