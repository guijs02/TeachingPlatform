using TeachingPlatform.Domain.Factories;
using TeachingPlatform.Domain.Validators;

namespace TeachingPlatform.Domain.Entities
{
    public class Course : Entity
    {
        public Course(Guid id,
                    string name,
                    string description,
                    Guid userId,
                    List<Module> modules) : base(id)
        {
            Name = name;
            Description = description;
            UserId = userId;
            Modules = modules;
            Progress = 0;
            Validate();
        }

        public string Name { get; private set; } = null!;
        public string Description { get; private set; } = null!;
        public Guid UserId { get; private set; }
        public List<Module> Modules { get; private set; } = null!;
        public decimal Progress { get; private set; }

        public void IncrementProgress()
        {
            var totalLessons = Modules.SelectMany(s => s.Lessons).Count();
            var lessons = Modules.SelectMany(s => s.Lessons);

            if (totalLessons == 0) return;

            var completedLessons = lessons.Count(x => x.IsCompleted);
            var value = ((decimal)completedLessons / totalLessons) * 100;

            Progress = Math.Round(value, 2);
        }
  
        private void Validate()
        {
            //TODO - Aplicar Notification Pattern em breve
            ValidationFactory.Validate(this, new CourseValidator());
        }
    }
}
