using System.Data.Common;
using TeachingPlatform.Domain.Entities;
using TeachingPlatform.Domain.Factories;
using TeachingPlatform.Domain.Interfaces;
using TeachingPlatform.Domain.Repositories;
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
            var course = CourseFactory.Create("Curso de Teste",
                                        "Curso de teste para integração",
                                        Guid.NewGuid(),
                                        ["module 1"],
                                        [new LessonDto("lesson1", false)] );

            var result = await _courseRepository.CreateAsync(course);

            Assert.NotNull(result);
            Assert.Equal(course.Id, result.Id);
            Assert.Equal(course.Name, result.Name);
            Assert.Equal(course.Description, result.Description);
            Assert.Equal(course.Progress, result.Progress);
            Assert.Equal(course.UserId, result.UserId);

            Assert.Equal(course.Modules.First().Name, result.Modules.First().Name);
            Assert.Equal(course.Modules.First().CourseId, result.Modules.First().CourseId);
            Assert.Equal(course.Modules.First().Id, result.Modules.First().Id);

            Assert.NotEmpty(result.Modules.First().Lessons);
            Assert.Equal(course.Modules.First().Lessons.First().Name, result.Modules.First().Lessons.First().Name);
            Assert.Equal(course.Modules.First().Lessons.First().Id, result.Modules.First().Lessons.First().Id);

        }

        [Fact]
        public async Task FinishLessonWithSuccess()
        {
            var course = CourseFactory.Create("Curso de Teste",
                                        "Curso de teste para integração",
                                        Guid.NewGuid(),
                                        ["module 1"],
                                        [new LessonDto("lesson1", false)]);

            await _courseRepository.CreateAsync(course);

            var result = await _courseRepository.FinishLessonAsync(course.Id, 
                                              course.Modules.First().Id, 
                                              course.Modules.First().Lessons.First().Id,
                                              course.UserId);


            Assert.True(_context.Context.Lesson.Any(s => s.IsCompleted));
            Assert.True(result);
        }

        [Fact]
        public async Task GetAllContentWithSuccess()
        {
            var course = CourseFactory.Create("Curso de Teste",
                                        "Curso de teste para integração", 
                                        Guid.NewGuid(),
                                        ["module 1"],
                                        [new LessonDto("lesson1", false)]);

            await _courseRepository.CreateAsync(course);

            var result = await _courseRepository.GetAllContentCourseAsync(course.Id, course.UserId);
            Assert.NotNull(result);
            Assert.NotEmpty(result.module);
            Assert.NotEmpty(result.module.First().lessons);


            Assert.Equal(course.Name, result.name);

            Assert.Equal(course.Modules.First().Name, result.module.First().name);
            //Assert.Equal(course.Modules.First().Id, result.module.First().id);

            Assert.Equal(course.Modules.First().Lessons.First().Name, result.module.First().lessons.First().name);
            //Assert.Equal(course.Modules.First().Lessons.First().Id, result.module.First().lessons.First().id);

        }

        public void Dispose()
        {
            _context.Context.Dispose();
            _context.connection.Close();
        }
    }
}
