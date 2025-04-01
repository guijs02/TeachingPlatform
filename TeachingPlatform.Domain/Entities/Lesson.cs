namespace TeachingPlatform.Domain.Entities
{
    public class Lesson : Entity
    {
        public Lesson(string name)
        {
            Name = name;
        }
        public string Name { get; private set; } = null!;
        public Guid ModuleId { get; set; }
    }
}
