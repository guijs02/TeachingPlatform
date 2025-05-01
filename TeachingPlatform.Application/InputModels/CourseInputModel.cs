
using System.Text.Json.Serialization;

namespace TeachingPlatform.Application.InputModels
{
    public class CourseInputModel
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        [JsonIgnore]
        public Guid TeacherId { get; set; }
        public List<ModuleInputModel> Modules { get; set; } = null!;
    }
}
