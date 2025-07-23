using System.ComponentModel.DataAnnotations;

namespace TeachingPlatform.Application.InputModels
{
    public sealed record LessonInputModel
    {
        [Required]
        public string Description { get; set; } = null!;
    }
}
