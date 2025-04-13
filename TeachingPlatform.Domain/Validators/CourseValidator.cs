using FluentValidation;
using TeachingPlatform.Domain.Entities;

namespace TeachingPlatform.Domain.Validators
{
    public class CourseValidator : AbstractValidator<Course>, IValidator<Course>
    {
        public CourseValidator()
        {
            RuleFor(s => s.Name)
           .NotEmpty().WithMessage("name must not be empty")
           .NotNull().WithMessage("name is required");

            RuleFor(s => s.Description)
           .NotEmpty().WithMessage("description must not be empty")
           .NotNull().WithMessage("description is required");

            RuleFor(s => s.UserId)
            .NotNull().WithMessage("userId is required")
            .Must(id => id != Guid.Empty).WithMessage("userId must be a valid GUID");

        }
    }
}
