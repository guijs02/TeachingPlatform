using Moq;
using TeachingPlatform.Application.InputModels;
using TeachingPlatform.Application.Services.User.Create;
using TeachingPlatform.Domain.Interfaces;

namespace TeachingPlatform.Test.ServicesTest.User
{
    public class CreateUserServiceTest
    {
        private readonly CreateUserService _service;
        private readonly Mock<IUserRepository> _repository;
        public CreateUserServiceTest()
        {
            _repository = new Mock<IUserRepository>();
            _service = new(_repository.Object);
        }

        [Fact]
        public async Task CreateUserWithSuccess()
        {
            var user = new UserCreateInputModel
            {
                UserName = "gui",
                ConfirmPassword = "123",
                Password = "123",
                TypeOfUser = Domain.Entities.EUserRole.TEACHER
            };

            var resultExpected = _repository.Setup(s => s.Create(It.IsAny<Domain.Entities.User>())).ReturnsAsync(true);

            var result = await _service.Create(user);

            Assert.True(result?.IsSuccess);
        }
        [Fact]
        public async Task CreateUserShouldBeFalse()
        {
            UserCreateInputModel? user = null;

            var resultExpected = _repository.Setup(s => s.Create(It.IsAny<Domain.Entities.User>())).ReturnsAsync(false);

            var result = await _service.Create(user);

            Assert.False(result?.IsSuccess);
        }


    }
}