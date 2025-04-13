using Microsoft.EntityFrameworkCore;
using TeachingPlatform.Application;
using TeachingPlatform.Application.InputModels;
using TeachingPlatform.Application.Responses;
using TeachingPlatform.Domain.Entities;
using TeachingPlatform.Domain.Interfaces;
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

        public async Task<IQueryable<Course>> GetAllCourses(int pageSize, int pageNumber, Guid userId)
        {
            return await Task.FromResult(_context.Course
                            .Where(c => c.TeacherId == userId)
                            .Select(s => new Course(s.Name, s.Description, userId))
                            .AsNoTracking());

        }
    }
}
