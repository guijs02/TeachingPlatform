using TeachingPlatform.Domain.Models;

namespace TeachingPlatform.Application.ViewModels
{
    public class CourseViewModel
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public Guid TeacherId { get; set; }
        public List<Module> Mudeles { get; set; } = null!;
        public Teacher Teacher { get; set; } = null!;
    }
}
