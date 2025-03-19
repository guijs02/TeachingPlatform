using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeachingPlatform.Infra.Models
{
    [Table("User")]
    public class UserModel : IdentityUser<Guid>
    {
        public string Password { get; set; } = null!;
        public EUserRole TypeOfUser { get; set; }
        public List<EnrollmentModel> Enrollments { get; set; } = new();

    }
    public enum EUserRole
    {
        TEACHER = 1,
        STUDENT = 2,
    }
}
