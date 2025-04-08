using TeachingPlatform.Domain.Factory;
using TeachingPlatform.Domain.Validators;

namespace TeachingPlatform.Domain.Entities
{
    public class Lesson : Entity
    {
        public Lesson(string name, Guid moduleId) : base()
        {
            Name = name;
            ModuleId = moduleId;
            Validate();
        }
        public string Name { get; private set; } = null!;
        public Guid ModuleId { get; set; }
        private void Validate()
        {
            //TODO - Aplicar Notification Pattern em breve
            ValidationFactory.Validate(this, new LessonValidator());
        }
    }
}
