using TeachingPlatform.Domain.Entities;

namespace TeachingPlatform.Application.Responses
{
    public class UserLoginInputModel
    {
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public EUserRole TypeOfUser { get; set; }
    }
}
