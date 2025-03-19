namespace TeachingPlatform.Domain.Entities
{
    public class Lesson : Entity
    {
        public Lesson(string name, Module module)
        {
            Name = name;
            Module = module;
        }
        public Lesson(string name)
        {
            Name = name;
        }
        public string Name { get; private set; } = null!;
        public Guid ModuleId { get; private set; }
        public Module Module { get; private set; } = null!;

    }
}
