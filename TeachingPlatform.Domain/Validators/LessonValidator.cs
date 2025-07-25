﻿using FluentValidation;
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
                .NotEmpty().WithMessage("moduleId must not be empty")
                .NotNull().WithMessage("moduleId is required");

        }
    }
}
