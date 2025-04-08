using TeachingPlatform.Domain.Factory;
using TeachingPlatform.Domain.Validators;

namespace TeachingPlatform.Domain.Entities
{
    public class Enrollment : Entity
    {
        public Enrollment(Guid studentId, Guid courseId) : base()
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
