using Microsoft.AspNetCore.Identity;

namespace TeachingPlatform.Domain.Models
{
    public class User : IdentityUser<Guid>
    {
        public string Password { get; set; } = null!;
        public EUserRole TypeOfUser { get; set; }
        public List<Enrollment> Enrollments { get; set; } = new();

    }
    public enum EUserRole
    {
        TEACHER = 1,
        STUDENT = 2,
    }
}
