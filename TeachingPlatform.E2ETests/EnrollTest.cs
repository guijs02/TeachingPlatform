using System.Net;
using System.Net.Http.Json;
using TeachingPlatform.Application;
using TeachingPlatform.Application.InputModels;
using TeachingPlatform.Application.Responses;
using TeachingPlatform.Domain.Entities;

namespace TeachingPlatform.E2ETests
{
    public class EnrollTest : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public EnrollTest(CustomWebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Should_Create_Enrollment_With_Success()
        {
            var course = new CourseInputModel
            {
                Name = "Curso de Teste",
                Description = "Curso de Teste",
                Mudeles = [new ModuleInputModel { Name = "Modulo 1", Lessons = new List<LessonInputModel> { new LessonInputModel { Description = "teste" } } }],
                TeacherId = Guid.NewGuid()
            };

            var courseId = Guid.NewGuid();

            var enrollment = new EnrollmentInputModel
            {
                CourseId = courseId,
                StudentId = Guid.NewGuid()
            };

            var login = await LoginUser(EUserRole.TEACHER);

            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", login?.Data?.ToString());

            // Buscar os cursos cadastrados
            await _client.PostAsJsonAsync("/api/v1/course/create-course", course);

            var login2 = await LoginUser(EUserRole.STUDENT);

            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", login2?.Data?.ToString());
            // Buscar os cursos cadastrados
            var response = await _client.PostAsJsonAsync("/api/v1/enrollment/create-enrollment", enrollment);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal("application/json", response.Content?.Headers?.ContentType?.MediaType);
        }   
        
        [Fact]
        public async Task Should_Be_Failure_When_User_Not_A_Teacher()
        {
            var course = new CourseInputModel
            {
                Name = "Curso de Teste",
                Description = "Curso de Teste",
                Mudeles = [new ModuleInputModel { Name = "Modulo 1", Lessons = new List<LessonInputModel> { new LessonInputModel { Description = "teste" } } }],
                TeacherId = Guid.NewGuid()
            };

            await LoginUser(EUserRole.STUDENT);

            // Buscar os cursos cadastrados
            var response = await _client.PostAsJsonAsync("/api/v1/course/create-course", course);

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
            //Assert.Equal("application/json", response.Content?.Headers?.ContentType?.MediaType);
        }
       
        public async Task<UserCreateInputModel> CreateUser(EUserRole role = EUserRole.TEACHER)
        {
            var user = new UserCreateInputModel
            {
                UserName = "gui",
                ConfirmPassword = "123",
                Password = "123",
                TypeOfUser = role
            };
            // Buscar os cursos cadastrados
            var response = await _client.PostAsJsonAsync("/api/v1/user/register", user);

            return user;
        }
        public async Task<Response<string>> LoginUser(EUserRole role = EUserRole.TEACHER)
        {
            await CreateUser(role);

            var user = new UserLoginInputModel
            {
                UserName = "gui",
                Password = "123",
                TypeOfUser = role
            };
            // Buscar os cursos cadastrados
            var response = await _client.PostAsJsonAsync("/api/v1/user/login", user);

            return await response.Content.ReadFromJsonAsync<Response<string>>();
        }

    }
}