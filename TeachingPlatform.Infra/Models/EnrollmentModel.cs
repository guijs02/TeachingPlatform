using System.ComponentModel.DataAnnotations.Schema;

namespace TeachingPlatform.Infra.Models
{
    [Table("Enrollment")]
    public class EnrollmentModel
    {
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public UserModel Student { get; set; } = null!;
        public Guid CourseId { get; set; }
        public CourseModel Course { get; set; } = null!;
        public DateTime CreatedAt { get; set; }

    }
}
