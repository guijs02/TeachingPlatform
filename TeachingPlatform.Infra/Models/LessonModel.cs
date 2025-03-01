using System.ComponentModel.DataAnnotations.Schema;

namespace TeachingPlatform.Domain.Models
{
    [Table("Lesson")]
    public class LessonModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public Guid ModuleId { get; set; }
        public ModuleModel Module { get; set; } = null!;

    }
}
