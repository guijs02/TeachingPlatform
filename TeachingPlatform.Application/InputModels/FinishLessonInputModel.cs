using System.ComponentModel.DataAnnotations;

namespace TeachingPlatform.Application.InputModels
{
    public class FinishLessonInputModel
    {
        [Required]
        public Guid CourseId { get; set; }
        [Required]
        public Guid LessonId { get; set; }
        [Required]
        public Guid ModuleId { get; set; }
    }
}
