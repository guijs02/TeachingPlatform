using System.ComponentModel.DataAnnotations.Schema;

namespace TeachingPlatform.Infra.Models
{
    [Table("Module")]
    public class ModuleModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public Guid CourseId { get; set; }
        public List<LessonModel> Lessons { get; set; } = null!;
        public virtual CourseModel Course { get; set; } = null!;
    }
}
