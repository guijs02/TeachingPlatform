using System.Net;
using System.Net.Http.Json;
using TeachingPlatform.Application.InputModels;

namespace TeachingPlatform.E2ETests
{
    public class UserTest : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public UserTest(CustomWebApplicationFactory<Program> factory)
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
    }
}