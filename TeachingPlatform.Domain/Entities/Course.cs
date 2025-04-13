using TeachingPlatform.Domain.Factory;
using TeachingPlatform.Domain.Validators;

namespace TeachingPlatform.Domain.Entities
{
    public class Course : Entity
    {
        public Course(string name,
            string description,
            Guid userId) : base()
        {
            Name = name;
            Description = description;
            UserId = userId;
            Mudules = [];
            Enrollments = [];

            Validate();
        }

        public string Name { get; private set; } = null!;
        public string Description { get; private set; } = null!;
        public Guid UserId { get; private set; }
        public List<Module> Mudules { get; private set; } = null!;
        public List<Enrollment> Enrollments { get; private set; } = null!;
        public void AddModule(Module module)
        {
            Mudules.Add(module);
        }
        private void Validate()
        {
            //TODO - Aplicar Notification Pattern em breve
            ValidationFactory.Validate(this, new CourseValidator());
        }
    }
}
