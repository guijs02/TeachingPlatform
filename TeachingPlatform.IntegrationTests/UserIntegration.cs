using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TeachingPlatform.Domain.Interfaces;
using TeachingPlatform.Infra.Models;
using TeachingPlatform.Infra.Repositories;
using TeachingPlatform.Test;
using Microsoft.AspNetCore.Http;
using TeachingPlatform.Infra.Context;
using Moq;
using TeachingPlatform.Domain.Entities;
using System.Data.Common;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;
using TeachingPlatform.Domain.Repositories;

namespace TeachingPlatform.IntegrationTests
{
    public class UserIntegration : IDisposable
    {
        private readonly IUserRepository _repository;
        private readonly UserManager<UserModel> _userManager;
        private readonly SignInManager<UserModel> _signInManager;
        private readonly (TeachingContext Context, DbConnection connection) _context;
        public UserIntegration()
        {
            _context = new SqliteDbContextFactory().CreateContext();

            _userManager = CreateUserManager();
            _signInManager = CreateSignInManager(_userManager);

            _repository = new UserRepository(_userManager, null, _signInManager);
        }

        [Fact]
        public async Task CreateUserWithSuccess()
        {
            // Arrange
            var result = await
                    _repository.Create(new User(Guid.NewGuid(),"gui", "123", Domain.Entities.EUserRole.TEACHER));

            Assert.True(result);
        }

        [Fact]
        public async Task LoginUserWithSuccess()
        {
            // Arrange
            var id = Guid.NewGuid();
            var user = new User(id, "GUI", "123", Domain.Entities.EUserRole.TEACHER);

            var resultCreate = await _repository.Create(user);

            var resultLogin = await _repository.Login(user);

            Assert.True(resultCreate);
            Assert.True(resultLogin);
        }

        [Fact]
        public async Task LogoutUserWithSuccess()
        {
            // Arrange
            var id = Guid.NewGuid();

            var user = new User(id, "GUI", "123", Domain.Entities.EUserRole.TEACHER);

            await _repository.Create(user);

            await _repository.Login(user);

            var result = _repository.LogoutAsync().IsCompletedSuccessfully;

            Assert.True(result);
        }

        private UserManager<UserModel> CreateUserManager()
        {
            var store = new UserStore<UserModel, IdentityRole<Guid>, TeachingContext, Guid>(_context.Context);
            var passwordHasher = new PasswordHasher<UserModel>();

            return new UserManager<UserModel>(
                store: store,
                null,
                passwordHasher,
                [],
                [],
                null,
                null,
                null,
                null);

        }

        private SignInManager<UserModel> CreateSignInManager(UserManager<UserModel> userManager)
        {
            var httpContext = new DefaultHttpContext
            {
                RequestServices = new ServiceCollection()
                    .AddLogging() // Add other necessary services here if needed, like UserManager or Identity services
                    .BuildServiceProvider()
            };

            var serviceCollection = new ServiceCollection();

            serviceCollection.AddLogging();

            // ✅ Mock IAuthenticationService
            var authenticationServiceMock = new Mock<IAuthenticationService>();
            serviceCollection.AddSingleton(authenticationServiceMock.Object);

            var serviceProvider = serviceCollection.BuildServiceProvider();
            httpContext.RequestServices = serviceProvider;

            // Mock IHttpContextAccessor
            var contextAccessor = new Mock<IHttpContextAccessor>();
            contextAccessor.Setup(x => x.HttpContext).Returns(httpContext);

            // Mock ClaimsPrincipalFactory
            var claimsFactory = new Mock<IUserClaimsPrincipalFactory<UserModel>>();

            // Mock other dependencies
            var options = Options.Create(new IdentityOptions());
            var logger = new Mock<ILogger<SignInManager<UserModel>>>();
            var authenticationSchemeProvider = new Mock<IAuthenticationSchemeProvider>();

            return new SignInManager<UserModel>(
                userManager, 
                contextAccessor.Object, 
                claimsFactory.Object, 
                options, 
                logger.Object,
                authenticationSchemeProvider.Object);
        }

        public void Dispose()
        {
            _context.Context.Dispose();
            _context.connection.Close();

        }
    }
}