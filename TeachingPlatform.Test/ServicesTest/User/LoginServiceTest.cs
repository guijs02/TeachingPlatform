using Moq;
using TeachingPlatform.Application.Responses;
using TeachingPlatform.Application.Services.Interfaces;
using TeachingPlatform.Application.Services.User.Login;
using TeachingPlatform.Domain.Exceptions;
using TeachingPlatform.Domain.Interfaces;
using TeachingPlatform.Domain.Repositories;

namespace TeachingPlatform.Test.ServicesTest.User
{
    public class LoginServiceTest
    {
        private readonly LoginUserService _service;
        private readonly Mock<ITokenService> _tokenService;
        private readonly Mock<IUserRepository> _userRepository;
        public LoginServiceTest()
        {
            _userRepository = new Mock<IUserRepository>();
            _tokenService = new Mock<ITokenService>();
            _service = new(_userRepository.Object, _tokenService.Object);
        }

        [Fact]
        public async Task LoginShouldGiveOK_WhenReturnsToken()
        {
            string expectedToken = "TOKEN_TESTE";

            var user = new UserLoginInputModel { UserName = "gui", Password = "123", TypeOfUser = Domain.Entities.EUserRole.TEACHER };

            _tokenService.Setup(t => t.GenerateToken(It.IsAny<Domain.Entities.User>())).Returns(expectedToken);
            _userRepository.Setup(s => s.Login(It.IsAny<Domain.Entities.User>())).ReturnsAsync(true);

            var result = await _service.Login(user);

            Assert.Equal(expectedToken, result.Data);
            _userRepository.Verify(repo => repo.Login(It.IsAny<Domain.Entities.User>()), Times.Once);
        }

        [Fact]
        public async Task LoginShouldGiveWrong_WhenLoginFailure()
        {
            string expectedMessage = "Dados inválidos ou incorretos!";

            var user = new UserLoginInputModel { UserName = "gui", Password = "123", TypeOfUser = Domain.Entities.EUserRole.TEACHER };

            _userRepository.Setup(s => s.Login(It.IsAny<Domain.Entities.User>())).ReturnsAsync(false);

            var result = await _service.Login(user);

            Assert.Null(result.Data);
            Assert.False(result.IsSuccess);
            Assert.Equal(expectedMessage, result.Message);
            _userRepository.Verify(repo => repo.Login(It.IsAny<Domain.Entities.User>()), Times.Once);
        }

        [Fact]
        public async Task Should_Logout_With_Success()
        {
            _userRepository.Setup(s => s.LogoutAsync());

            var result = await _service.LogoutAsync();
            Assert.True(result.IsSuccess);
            Assert.Equal("Logout feito com sucesso", result.Message);
            _userRepository.Verify(repo => repo.LogoutAsync(), Times.Once);
        }

    }
}
