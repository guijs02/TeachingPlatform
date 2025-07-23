using System.Net.Http.Json;
using TeachingPlatform.Application;
using TeachingPlatform.Application.InputModels;
using TeachingPlatform.Application.Responses;
using TeachingPlatform.Domain.Entities;

namespace TeachingPlatform.E2ETests
{
    internal class UserService
    {
        private static async Task<UserCreateInputModel> CreateUser(HttpClient client, EUserRole role = EUserRole.TEACHER)
        {
            var user = new UserCreateInputModel
            {
                UserName = "gui",
                ConfirmPassword = "123",
                Password = "123",
                TypeOfUser = role
            };
            // Buscar os cursos cadastrados
            await client.PostAsJsonAsync("/api/v1/user/register", user);

            return user;
        }
        internal static async Task<Response<string>> CreateLoginUser(HttpClient client, Domain.Entities.EUserRole role = EUserRole.TEACHER)
        {
            await CreateUser(client, role);

            var user = new UserLoginInputModel
            {
                UserName = "gui",
                Password = "123",
                TypeOfUser = role
            };
            // Buscar os cursos cadastrados
            var response = await client.PostAsJsonAsync("/api/v1/user/login", user);

            return await response.Content.ReadFromJsonAsync<Response<string>>();
        }

    }
}
