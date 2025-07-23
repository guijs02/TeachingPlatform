using FluentValidation;
using TeachingPlatform.Domain.Entities;

namespace TeachingPlatform.Domain.Validators
{
    public class EnrollmentValidator : AbstractValidator<Enrollment>, IValidator<Enrollment>
    {
        public EnrollmentValidator()
        {
           

        }
    }
}
