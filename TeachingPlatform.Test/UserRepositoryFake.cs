using TeachingPlatform.Domain.Interfaces;
using TeachingPlatform.Domain.Models;

namespace TeachingPlatform.Test
{
    public class UserRepositoryFake : IUserRepository
    {
        public async Task<bool> Create(User loginUser)
        {
            await Task.Delay(2000);
            if (loginUser == null) return false;

            return true;
        }

        public async Task<string> Login(User loginUser)
        {
            var users = new List<User>()
            {
                new() { Password = "123", UserName = "gui" },
                new() { Password = "teste", UserName = "gui" },
                new() { Password = "sp123", UserName = "guilherme" },
            };

            bool result = users.Any(a => a.Password == loginUser.Password &&
                                    a.UserName == loginUser.UserName);

            await Task.Delay(2000);

            if (!result)
                throw new ApplicationException("Usuario não existe ou login incorreto");

            return "token";

        }
    }
}
