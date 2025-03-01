namespace TeachingPlatform.Domain.Entities
{
    public class Lesson
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public Guid ModuleId { get; set; }
        public Module Module { get; set; } = null!;

    }
}
