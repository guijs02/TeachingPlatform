using TeachingPlatform.Domain.Models;

namespace TeachingPlatform.Application.ViewModels
{
    public class UserLoginViewModel
    {
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public EUserRole TypeOfUser { get; set; }
    }
}
