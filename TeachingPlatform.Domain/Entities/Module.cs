using TeachingPlatform.Domain.Factory;
using TeachingPlatform.Domain.Validators;

namespace TeachingPlatform.Domain.Entities
{
    public class Module : Entity
    {
        public Module(string name, Guid courseId) : base()
        {
            Name = name;
            CourseId = courseId;
            Lessons = new();
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

        public void AddLesson(Lesson lesson)
        {
            Lessons.Add(lesson);
        }

    }
}
