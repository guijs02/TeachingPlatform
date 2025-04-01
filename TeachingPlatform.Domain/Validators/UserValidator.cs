using FluentValidation;
using TeachingPlatform.Domain.Entities;

namespace TeachingPlatform.Domain.Validators
{
    public class UserValidator : AbstractValidator<User>, IValidator<User>
    {
        public UserValidator()
        {
            RuleFor(s => s.UserName)
           .NotEmpty().WithMessage("username must not be empty")
           .NotNull().WithMessage("username is required");

            RuleFor(s => s.TypeOfUser)
           .IsInEnum().WithMessage("type of user is required");

            RuleFor(s => s.Password)
                .NotEmpty().WithMessage("password must not be empty")
                .NotNull().WithMessage("password is required");

        }
    }
}
