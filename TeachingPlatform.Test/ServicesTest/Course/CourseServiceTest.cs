using Moq;
using TeachingPlatform.Application.Extension;
using TeachingPlatform.Application.InputModels;
using TeachingPlatform.Application.Services.Course;
using TeachingPlatform.Domain.Interfaces;
using TeachingPlatform.Domain.Repositories;

namespace TeachingPlatform.Test.ServicesTest.Course
{
    public class CourseServiceTest
    {
        private readonly CreateCourseService _service;
        private readonly Mock<ICourseRepository> _repository;
        public CourseServiceTest()
        {
            _repository = new Mock<ICourseRepository>();
            _service = new(_repository.Object);
        }

        [Fact]
        public async Task CreateCourseWithSuccess()
        {
            var courseInput = new CourseInputModel
            {
                Description = "Test",
                Name = "Test",
                Modules = new List<ModuleInputModel>
                {
                    new ModuleInputModel
                    {
                        Name = "Test",
                        Lessons = new List<LessonInputModel>
                        {
                            new LessonInputModel { Description = "LessonA" }
                        }
                    }
                },
            };

            var courseExpected = courseInput.ToEntity();
            _repository.Setup(s => s.CreateAsync(It.IsAny<Domain.Entities.Course>())).ReturnsAsync(courseExpected);

            var result = await _service.CreateAsync(courseInput, Guid.NewGuid());

            var lessons = courseExpected.Modules.SelectMany(sm => sm.Lessons);

            Assert.Equal(courseExpected.Name, result?.Data?.name);
            Assert.Equal(courseExpected.Description, result?.Data?.description);
            Assert.NotEmpty(courseExpected.Modules);

            Assert.NotEmpty(courseExpected.Modules.First().Name);
            Assert.NotNull(courseExpected.Modules.First().Name);
            Assert.NotEqual(Guid.Empty, courseExpected.Modules.First().CourseId);
            Assert.NotEqual(Guid.Empty, courseExpected.Modules.First().Id);

            Assert.NotEmpty(lessons);
            Assert.NotEmpty(lessons.First().Name);
            Assert.NotNull(lessons.First().Name);
            Assert.NotEqual(Guid.Empty, lessons.First().Id);
            //Assert.NotEqual(Guid.Empty, lessons.First().ModuleId);

        }

        [Fact]
        public void SholudFinishLessonsWithSuccess()
        {
            var input = new
            {
                CourseId = Guid.NewGuid(),
                ModuleId = Guid.NewGuid(),
                LessonId = Guid.NewGuid()
            };

            var course = new Domain.Entities.Course(Guid.NewGuid(),"Test", "Test", Guid.NewGuid(), []);
        }

     
    }
}
