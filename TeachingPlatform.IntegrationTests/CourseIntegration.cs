using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachingPlatform.Domain.Entities;
using TeachingPlatform.Domain.Interfaces;
using TeachingPlatform.Infra.Context;
using TeachingPlatform.Infra.Repositories;
using TeachingPlatform.Test;

namespace TeachingPlatform.IntegrationTests
{
    public class CourseIntegration : IDisposable
    {
        private readonly ICourseRepository _courseRepository;
        private readonly (TeachingContext Context, DbConnection connection) _context;
        public CourseIntegration()
        {
            _context = new SqliteDbContextFactory().CreateContext();
            _courseRepository = new CourseRepository(_context.Context);
        }

        [Fact]
        public async Task CreateCourseWithSuccess()
        {
            var course = new Course(
                "Test",
                "Test",
                Guid.NewGuid());

            course.AddModule(new Module("Test", Guid.NewGuid()));

            course.AddEnrollment(new Enrollment(
                Guid.NewGuid(),
                Guid.NewGuid()));

            var result = await _courseRepository.Create(course);

            Assert.NotNull(result);
            Assert.Equal(course.Name, result.Name);
            Assert.Equal(course.Description, result.Description);
            Assert.Equal(course.TeacherId, result.TeacherId);
            Assert.Equal(course.Mudules.First().Name, result.Mudules.First().Name);
            Assert.Equal(course.Mudules.First().CourseId, result.Mudules.First().CourseId);
        }

        public void Dispose()
        {
            _context.Context.Dispose();
            _context.connection.Close();
        }
    }
}
