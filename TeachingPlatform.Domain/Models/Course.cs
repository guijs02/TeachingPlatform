using System.ComponentModel.DataAnnotations.Schema;

namespace TeachingPlatform.Domain.Models
{
    public class Course
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public Guid TeacherId { get; set; }
        public List<Module> Mudules { get; set; } = null!;
        public List<Enrollment> Enrollments { get; set; } = null!;
    }
}
