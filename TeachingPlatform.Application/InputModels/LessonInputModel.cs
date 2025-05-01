using System.ComponentModel.DataAnnotations;

namespace TeachingPlatform.Application.InputModels
{
    public class LessonInputModel
    {
        [Required]
        public string Description { get; set; } = null!;
    }
}
