using Moq;
using TeachingPlatform.Application.Extension;
using TeachingPlatform.Application.InputModels;
using TeachingPlatform.Domain.Interfaces;

namespace TeachingPlatform.Test
{
    public class CourseServiceTest
    {
        private readonly CourseService _service;
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
                Mudeles = new List<ModuleInputModel>
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

            var courseExpected = courseInput.ToModel();
            var resultExpected = _repository.Setup(s => s.Create(It.IsAny<Course>())).ReturnsAsync(courseExpected);

            var result = await _service.Create(courseInput, Guid.NewGuid());

            Assert.Equal(courseExpected.Name, result.name);
            Assert.Equal(courseExpected.Description, result.description);
        }
    }
}
