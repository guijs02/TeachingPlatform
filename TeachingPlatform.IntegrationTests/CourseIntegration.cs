using System.Data.Common;
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
            course.Mudules.First().AddLesson(new Lesson("LessonA", Guid.NewGuid()));

            var result = await _courseRepository.Create(course);

            Assert.NotNull(result);
            Assert.Equal(course.Name, result.Name);
            Assert.Equal(course.Description, result.Description);
            Assert.Equal(course.TeacherId, result.TeacherId);

            Assert.Equal(course.Mudules.First().Name, result.Mudules.First().Name);
            Assert.Equal(course.Mudules.First().CourseId, result.Mudules.First().CourseId);
            Assert.Equal(course.Mudules.First().Id, result.Mudules.First().Id);

            Assert.NotEmpty(result.Mudules.First().Lessons);
            Assert.Equal(course.Mudules.First().Lessons.First().Name, result.Mudules.First().Lessons.First().Name);
            Assert.Equal(course.Mudules.First().Lessons.First().Id, result.Mudules.First().Lessons.First().Id);
            Assert.Equal(course.Mudules.First().Lessons.First().ModuleId, result.Mudules.First().Lessons.First().ModuleId);
        }

        public void Dispose()
        {
            _context.Context.Dispose();
            _context.connection.Close();
        }
    }
}
