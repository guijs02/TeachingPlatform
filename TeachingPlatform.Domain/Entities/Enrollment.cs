using TeachingPlatform.Domain.Factories;
using TeachingPlatform.Domain.Validators;

namespace TeachingPlatform.Domain.Entities
{
    public class Enrollment : Entity
    {
        public Enrollment(Guid id, Guid studentId, Guid courseId) : base(id)
        {
            StudentId = studentId;
            CourseId = courseId;
            CreatedAt = DateTime.UtcNow;
            Validate();
        }
     
        public Guid StudentId { get; private set; }
        public Guid CourseId { get; private set; }
        public DateTime CreatedAt { get; private set; }
        private void Validate()
        {
            //TODO - Aplicar Notification Pattern em breve
            ValidationFactory.Validate(this, new EnrollmentValidator());
        }

    }
}
