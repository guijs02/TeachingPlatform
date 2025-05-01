using System.ComponentModel.DataAnnotations;

namespace TeachingPlatform.Application.InputModels
{
    public class ModuleInputModel
    {
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public List<LessonInputModel> Lessons { get; set; } = new();
    }
}
