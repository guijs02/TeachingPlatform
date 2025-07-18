using TeachingPlatform.Domain.Exceptions;
using TeachingPlatform.Domain.Factories;
using TeachingPlatform.Domain.Validators;
using TeachingPlatform.Domain.ValueObjects;

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
     
        public StudentId StudentId { get; private set; }
        public CourseId CourseId { get; private set; }
        public DateTime CreatedAt { get; private set; }
        private void Validate()
        {
            //TODO - Aplicar Notification Pattern em breve
            ValidationFactory.Validate(this, new EnrollmentValidator());

            if (Notification.HasErrors())
            {
                throw new DomainException(Notification.GetErrors());
            }
        }

    }
}
