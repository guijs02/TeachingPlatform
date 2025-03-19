using System.ComponentModel.DataAnnotations.Schema;

namespace TeachingPlatform.Infra.Models
{
    [Table("Course")]
    public class CourseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public Guid TeacherId { get; set; }
        public List<ModuleModel> Mudules { get; set; } = null!;
        public List<EnrollmentModel> Enrollments { get; set; } = null!;
    }
}
