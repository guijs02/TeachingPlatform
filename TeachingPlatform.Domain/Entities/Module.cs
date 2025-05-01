using TeachingPlatform.Domain.Factories;
using TeachingPlatform.Domain.Validators;

namespace TeachingPlatform.Domain.Entities
{
    public class Module : Entity
    {
        public Module(Guid id, string name, Guid courseId, List<Lesson> lessons) : base(id)
        {
            Name = name;
            CourseId = courseId;
            Lessons = lessons;
            Validate();
        }

        public string Name { get; private set; } = null!;
        public Guid CourseId { get; private set; }
        public List<Lesson> Lessons { get; private set; } = null!;

        private void Validate()
        {
            //TODO - Aplicar Notification Pattern em breve
            ValidationFactory.Validate(this, new ModuleValidator());
        }
    }
}
