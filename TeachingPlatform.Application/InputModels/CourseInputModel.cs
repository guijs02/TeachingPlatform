namespace TeachingPlatform.Application.InputModels
{
    public class CourseInputModel
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public Guid TeacherId { get; set; }
        public List<ModuleInputModel> Mudeles { get; set; } = null!;
    }
}
