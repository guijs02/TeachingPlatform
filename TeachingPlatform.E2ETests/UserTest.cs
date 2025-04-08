using System.Net;
using System.Net.Http.Json;
using TeachingPlatform.Application;
using TeachingPlatform.Application.InputModels;
using TeachingPlatform.Application.Responses;

namespace TeachingPlatform.E2ETests
{
    public class CourseTest : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public CourseTest(CustomWebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

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
                TypeOfUser = Domain.Entities.EUserRole.TEACHER
            };

            // Buscar os cursos cadastrados
            var response = await _client.PostAsJsonAsync("/api/v1/user/register", user);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.Equal("application/problem+json", response.Content?.Headers?.ContentType?.MediaType);
        }
    }
}