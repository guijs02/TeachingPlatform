using FluentValidation;
using TeachingPlatform.Domain.Entities;

namespace TeachingPlatform.Domain.Validators
{
    public class EnrollmentValidator : AbstractValidator<Enrollment>, IValidator<Enrollment>
    {
        public EnrollmentValidator()
        {
            RuleFor(s => s.CourseId)
           .NotEmpty().WithMessage("courseId must not be empty")
           .NotNull().WithMessage("username is required");

            RuleFor(s => s.StudentId)
           .IsInEnum().WithMessage("type of user is required");

        }
    }
}
