using System.Net;
using System.Net.Http.Json;
using TeachingPlatform.Application;
using TeachingPlatform.Application.InputModels;
using TeachingPlatform.Application.Responses;
using TeachingPlatform.Domain.Entities;

namespace TeachingPlatform.E2ETests
{
    public class UserTest(CustomWebApplicationFactory<Program> factory) : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly HttpClient _client = factory.CreateClient();

        [Fact]
        public async Task Should_Register_User()
        {
            var user = new UserCreateInputModel
            {
                UserName = "gui",
                ConfirmPassword = "123",
                Password = "123",
                TypeOfUser = Domain.Entities.EUserRole.TEACHER
            };

            // Buscar os cursos cadastrados
            var response = await _client.PostAsJsonAsync("/api/v1/user/register", user);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal("application/json", response.Content?.Headers?.ContentType?.MediaType);
        }

        [Fact]
        public async Task Should_Give_Fail_Password_IsNotTheSame_ConfirmPassword()
        {
            var user = new UserCreateInputModel
            {
                UserName = "gui",
                ConfirmPassword = "123",
                Password = "1232",
                TypeOfUser = EUserRole.TEACHER
            };

            // Buscar os cursos cadastrados
            var response = await _client.PostAsJsonAsync("/api/v1/user/register", user);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.Equal("application/problem+json", response.Content?.Headers?.ContentType?.MediaType);
        }   
        
        [Fact]
        public async Task Should_Logout_User_With_Success()
        {
            // Buscar os cursos cadastrados
            var login = await UserService.CreateLoginUser(_client, EUserRole.STUDENT);

            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", login?.Data?.ToString());

            //// Buscar os cursos cadastrados
            var response = await _client.DeleteAsync("/api/v1/user/logout");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }  
        
        [Fact]
        public async Task Should_Give_Wrong_When_Logout_Not_Authenticated()
        {
            //// Buscar os cursos cadastrados
            var response = await _client.DeleteAsync("/api/v1/user/logout");

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }
    }
}