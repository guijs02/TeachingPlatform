using System.ComponentModel.DataAnnotations.Schema;

namespace TeachingPlatform.Infra.Models
{
    [Table("Lesson")]
    public class LessonModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public Guid ModuleId { get; set; }
        public bool IsCompleted { get; set; }
        public ModuleModel Module { get; set; } = null!;

    }
}
