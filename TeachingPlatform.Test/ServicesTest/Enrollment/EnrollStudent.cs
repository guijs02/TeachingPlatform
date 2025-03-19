using Moq;
using TeachingPlatform.Application.InputModels;
using TeachingPlatform.Domain.Interfaces;

namespace TeachingPlatform.Test.ServicesTest.Enrollment
{
    public class CreateEnrollTest
    {
        private readonly CreateEnrollService _service;
        private readonly Mock<IEnrollmentRepository> _repository;
        public CreateEnrollTest()
        {
            _repository = new Mock<IEnrollmentRepository>();
            _service = new(_repository.Object);
        }

        [Fact]
        public async Task EnrollStudentWithSuccess()
        {
            var enroll = new EnrollmentInputModel
            {
                StudentId = Guid.NewGuid(),
                CourseId = Guid.NewGuid(),
            };

            var entity = new Domain.Entities.Enrollment(
                Guid.NewGuid(),
                Guid.NewGuid(),
                new Domain.Entities.User("Gui", "Senha", Domain.Entities.EUserRole.TEACHER),
                new Domain.Entities.Course("API REST", "http", Guid.NewGuid(), []));


            var resultExpected = _repository.Setup(s => s.Create(It.IsAny<Domain.Entities.Enrollment>()))
                                            .ReturnsAsync(entity);

            var result = await _service.Create(enroll);

            Assert.Equal(entity.Student.UserName, result?.Data?.studentName);
            Assert.Equal(entity.Course.Name, result?.Data?.course);
        }

        [Fact]
        public async Task CreateUserShouldBeFalse()
        {
            EnrollmentInputModel? input = null;

            var result = await _service.Create(input);

            Assert.False(result?.IsSuccess);
        }

    }
}
