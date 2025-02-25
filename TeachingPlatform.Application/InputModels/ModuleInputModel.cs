namespace TeachingPlatform.Application.InputModels
{
    public class ModuleInputModel
    {
        public string Name { get; set; } = null!;
        public List<LessonInputModel> Lessons { get; set; } = new();
    }
}
