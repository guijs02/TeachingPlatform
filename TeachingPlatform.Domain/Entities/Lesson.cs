namespace TeachingPlatform.Domain.Entities
{
    public class Lesson : Entity
    {
        public Lesson(string name, Guid moduleId) : base()
        {
            Name = name;
            ModuleId = moduleId;
        }
        public string Name { get; private set; } = null!;
        public Guid ModuleId { get; set; }
    }
}
