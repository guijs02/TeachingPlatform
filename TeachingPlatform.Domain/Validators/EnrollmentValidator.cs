using FluentValidation;
using TeachingPlatform.Domain.Entities;

namespace TeachingPlatform.Domain.Validators
{
    public class EnrollmentValidator : AbstractValidator<Enrollment>, IValidator<Enrollment>
    {
        public EnrollmentValidator()
        {
            RuleFor(s => s.CourseId)
           .NotNull().WithMessage("courseId is required")
           .Must(id => id != Guid.Empty).WithMessage("courseId must be a valid GUID");
            
            RuleFor(s => s.StudentId)
           .NotNull().WithMessage("studentId is required")
           .Must(id => id != Guid.Empty).WithMessage("studentId must be a valid GUID");

        }
    }
}
