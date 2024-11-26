using Microsoft.AspNetCore.Identity;

namespace TeachingPlatform.Domain.Models
{
    public class User : IdentityUser
    {
        public string Password { get; set; } = null!;
        public ETypeOfUser TypeOfUser { get; set; }
    }
    public enum ETypeOfUser
    {
        ADMIN = 0,
        INSTRUTOR = 1,
        ALUNO = 2,
    }
}
