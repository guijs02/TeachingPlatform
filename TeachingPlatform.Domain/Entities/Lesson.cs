using TeachingPlatform.Domain.Exceptions;
using TeachingPlatform.Domain.Factories;
using TeachingPlatform.Domain.Validators;
using TeachingPlatform.Domain.ValueObjects;

namespace TeachingPlatform.Domain.Entities
{
    public class Lesson : Entity
    {
        public Lesson(Guid id, string name, Guid moduleId, bool isCompleted = false) : base(id)
        {
            Name = name;
            ModuleId = moduleId;
            IsCompleted = isCompleted;
            Validate();
        }
        public string Name { get; private set; } = null!;
        public ModuleId ModuleId { get; private set; }
        public bool IsCompleted { get; private set; }

        public void FinishLesson()
        {
            IsCompleted = true;
        }
        private void Validate()
        {
            ValidationFactory.Validate(this, new LessonValidator());

            if (Notification.HasErrors()) { 
                throw new DomainException(Notification.GetErrors());
            }
        }
    }
}
