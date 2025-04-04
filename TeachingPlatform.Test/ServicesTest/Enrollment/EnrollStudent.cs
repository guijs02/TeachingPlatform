using Moq;
using TeachingPlatform.Application.InputModels;
using TeachingPlatform.Domain.Entities;
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
                Guid.NewGuid());

            string courseName = "APi Rest";
            _repository.Setup(s => s.Create(It.IsAny<Domain.Entities.Enrollment>()))
                                            .ReturnsAsync(enroll.CourseId);

            _repository.Setup(s => s.GetNameByCourseStudentAsync(It.IsAny<Guid>(), It.IsAny<Guid>()))
                                            .ReturnsAsync(courseName);

            var result = await _service.Create(enroll);

            Assert.Equal(courseName, result?.Data?.course);
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
