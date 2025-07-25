﻿using FluentValidation;
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
            
            RuleFor(s => s.Lessons)
          .NotEmpty().WithMessage("lessons must not be empty")
          .NotNull().WithMessage("lessons is required");

        }
    }
}
