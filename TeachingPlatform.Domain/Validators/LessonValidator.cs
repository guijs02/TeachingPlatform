using FluentValidation;
using TeachingPlatform.Domain.Entities;

namespace TeachingPlatform.Domain.Validators
{
    public class LessonValidator : AbstractValidator<Lesson>, IValidator<Lesson>
    {
        public LessonValidator()
        {
            RuleFor(s => s.Name)
           .NotEmpty().WithMessage("name must not be empty")
           .NotNull().WithMessage("name is required");

            RuleFor(s => s.ModuleId)
           .NotNull().WithMessage("moduleId is required")
           .Must(id => id != Guid.Empty).WithMessage("moduleId must be a valid GUID");

        }
    }
}
