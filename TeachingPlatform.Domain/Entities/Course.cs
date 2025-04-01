namespace TeachingPlatform.Domain.Entities
{
    public class Course : Entity
    {
        public Course(string name,
            string description,
            Guid teacherId)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            TeacherId = teacherId;
            Mudules = new();
            Enrollments = new();
        }

        public string Name { get; private set; } = null!;
        public string Description { get; private set; } = null!;
        public Guid TeacherId { get; private set; }
        public List<Module> Mudules { get; private set; } = null!;
        public List<Enrollment> Enrollments { get; private set; } = null!;

        public void AddModule(Module module)
        {
            Mudules.Add(module);
        }
        public void AddEnrollment(Enrollment enrollment)
        {
            Enrollments.Add(enrollment);
        }
    }
}
