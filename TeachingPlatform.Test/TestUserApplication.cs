using Moq;
using TeachingPlatform.Application.InputModels;
using TeachingPlatform.Application.Responses;
using TeachingPlatform.Application.Services;
using TeachingPlatform.Domain.Interfaces;
using TeachingPlatform.Domain.Models;

namespace TeachingPlatform.Test
{
    public class TestUserApplication
    {
        private readonly UserService _service;
        private readonly Mock<IUserRepository> _repository;
        public TestUserApplication()
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
                TypeOfUser = EUserRole.TEACHER
            };

            var resultExpected = _repository.Setup(s => s.Create(It.IsAny<User>())).ReturnsAsync(true);

            var result = await _service.Create(user);

            Assert.True(result.isSucceeded);
        }
        [Fact]
        public async Task CreateUserShouldBeFalseWhenArgumentIsNull()
        {
            UserCreateInputModel? user = null;

            var resultExpected = _repository.Setup(s => s.Create(It.IsAny<User>())).ReturnsAsync(false);

            var result = await _service.Create(user);

            Assert.False(result.isSucceeded);
        }

        [Fact]
        public async Task LoginWithSuccess()
        {
            string expectedToken = "ahdljfbadfbaodfbodaf341e13jobzxvczx";

            var user = new UserLoginInputModel { UserName = "gui", Password = "123" };

            var resultExpected = _repository.Setup(s => s.Login(It.IsAny<User>())).ReturnsAsync(expectedToken);

            var result = await _service.Login(user);

            Assert.Equal(expectedToken, result.token);
            _repository.Verify(repo => repo.Login(It.IsAny<User>()), Times.Once);
        }
    }
}