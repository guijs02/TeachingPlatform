using TeachingPlatform.Application.Services;
using TeachingPlatform.Application.ViewModels;
using TeachingPlatform.Domain.Models;

namespace TeachingPlatform.Test
{
    public class TestUserApplication
    {
        private readonly UserService _service;
        private readonly UserRepositoryFake _repository;
        public TestUserApplication()
        {
            _repository = new UserRepositoryFake();
            _service = new(_repository);
        }

        [Fact]
        public void CreateUserWithSuccess()
        {
            var user = new UserCreateViewModel { UserName = "gui", ConfirmPassword = "123", Password = "123" };

            var result = _service.Create(user);

            Assert.True(result?.Result);
        }
        [Fact]
        public void CreateUserShouldBeFalseWhenArgumentIsNull()
        {
            UserCreateViewModel? user = null;

            var result = _service.Create(user);

            Assert.False(result?.Result);
        }

        [Fact]
        public void LoginWithSuccess()
        {
            var user = new UserLoginViewModel { UserName = "gui", Password = "123" };

            var result = _service.Login(user);

            Assert.Equal("token", result?.Result);
        }

        [Fact]
        public async Task LoginShouldGetAExecptionWhenUserNotExist()
        {
            var user = new UserLoginViewModel { UserName = "guilherme", Password = "1234" };

            await Assert.ThrowsAsync<ApplicationException>(() => _service.Login(user));
        }

    }
}