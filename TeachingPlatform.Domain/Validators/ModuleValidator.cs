using FluentValidation;
using TeachingPlatform.Domain.Entities;

namespace TeachingPlatform.Domain.Validators
{
    public class ModuleValidator : AbstractValidator<Module>, IValidator<Module>
    {
        public ModuleValidator()
        {
            RuleFor(s => s.Name)
          .NotEmpty().WithMessage("name must not be empty")
          .NotNull().WithMessage("name is required");

            RuleFor(s => s.CourseId)
           .NotNull().WithMessage("courseId is required")
           .Must(id => id != Guid.Empty).WithMessage("moduleId must be a valid GUID");

        }
    }
}
