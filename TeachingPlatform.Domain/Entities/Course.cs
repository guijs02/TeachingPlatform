namespace TeachingPlatform.Domain.Entities
{
    public class Course : Entity
    {
        public Course(string name,
            string description,
            Guid teacherId,
            List<Module> mudules,
            List<Enrollment> enrollments)
        {
            Name = name;
            Description = description;
            TeacherId = teacherId;
            Mudules = mudules;
            Enrollments = enrollments;
        }

        public Course(string name,
            string description,
            Guid teacherId,
            List<Module> mudules)
        {
            Name = name;
            Description = description;
            TeacherId = teacherId;
            Mudules = mudules;
        }

        public string Name { get; private set; } = null!;
        public string Description { get; private set; } = null!;
        public Guid TeacherId { get; private set; }
        public List<Module> Mudules { get; private set; } = null!;
        public List<Enrollment> Enrollments { get; private set; } = null!;
    }
}
