using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using TeachingPlatform.Application;
using TeachingPlatform.Application.InputModels;
using TeachingPlatform.Application.Services.Course;
using TeachingPlatform.Domain.Entities;
using TeachingPlatform.Domain.Responses;

namespace TeachingPlatform.E2ETests
{
    public class CourseTest(CustomWebApplicationFactory<Program> factory) : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly HttpClient _client = factory.CreateClient();

        [Fact]
        public async Task Should_Create_Course_With_Success()
        {
            var course = new CourseInputModel
            {
                Name = "Curso de Teste",
                Description = "Curso de Teste",
                Modules = [new ModuleInputModel { Name = "Modulo 1", Lessons = new List<LessonInputModel> { new LessonInputModel { Description = "teste" } } }],
                TeacherId = Guid.NewGuid()
            };

            var login = await UserService.CreateLoginUser(_client);

            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", login?.Data?.ToString());

            // Buscar os cursos cadastrados
            var response = await _client.PostAsJsonAsync("/api/v1/course/create-course", course);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal("application/json", response.Content?.Headers?.ContentType?.MediaType);
        }

        [Fact]
        public async Task Should_Get_All_Courses_From_Teacher()
        {
            var course = new CourseInputModel
            {
                Name = "Curso de Teste",
                Description = "Curso de Teste",
                Modules = [new ModuleInputModel { Name = "Modulo 1", Lessons = new List<LessonInputModel> { new LessonInputModel { Description = "teste" } } }],
                TeacherId = Guid.NewGuid()
            };


            var login = await UserService.CreateLoginUser(_client);

            // Buscar os cursos cadastrados

            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", login?.Data?.ToString());

            await _client.PostAsJsonAsync("/api/v1/course/create-course", course);

            // Buscar os cursos cadastrados
            var response = await _client.GetAsync("/api/v1/course");
            var obj = await response.Content.ReadFromJsonAsync<PagedResponse<List<CourseGetAllResponse>>>();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(1, obj?.TotalCount);
            Assert.Equal("application/json", response.Content?.Headers?.ContentType?.MediaType);
        }

        [Fact]
        public async Task Should_Get_All_Content_Course()
        {
            var course = new CourseInputModel
            {
                Name = "Curso de Teste",
                Description = "Curso de Teste",
                Modules = [new ModuleInputModel { Name = "Modulo 1", Lessons = new List<LessonInputModel> { new LessonInputModel { Description = "teste" } } }],
                TeacherId = Guid.NewGuid()
            };


            var login = await UserService.CreateLoginUser(_client);

            // Buscar os cursos cadastrados

            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", login?.Data?.ToString());

            var courseResponse = await _client.PostAsJsonAsync("/api/v1/course/create-course", course);

            var responseContent = await courseResponse.Content.ReadAsStringAsync();

            // Parse the JSON response
            using var jsonDocument = JsonDocument.Parse(responseContent);

            // Access the "Data" property and then the "Id" property
            var dataElement = jsonDocument.RootElement.GetProperty("data");
            var id = dataElement.GetProperty("id").GetGuid();

            // Buscar os cursos cadastrados
            var response = await _client.GetAsync($"/api/v1/course/get-all-content/{id}");

            var obj = await response.Content.ReadFromJsonAsync<Response<GetAllContentCourseResponse>>();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(1, obj?.Data?.module.Count());
            Assert.Equal(1, obj?.Data?.module.First().lessons.Count());
            Assert.Equal("application/json", response.Content?.Headers?.ContentType?.MediaType);
        }

        [Fact]
        public async Task Should_Be_Failure_When_User_Not_A_Teacher()
        {
            var course = new CourseInputModel
            {
                Name = "Curso de Teste",
                Description = "Curso de Teste",
                Modules = [new ModuleInputModel { Name = "Modulo 1", Lessons = new List<LessonInputModel> { new LessonInputModel { Description = "teste" } } }],
                TeacherId = Guid.NewGuid()
            };

            await UserService.CreateLoginUser(_client, EUserRole.STUDENT);

            // Buscar os cursos cadastrados
            var response = await _client.PostAsJsonAsync("/api/v1/course/create-course", course);

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

    }
}