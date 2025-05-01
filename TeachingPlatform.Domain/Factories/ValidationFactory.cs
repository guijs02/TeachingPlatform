using FluentValidation;
using TeachingPlatform.Domain.Entities;

namespace TeachingPlatform.Domain.Factories
{
    public class ValidationFactory
    {
        public static void Validate<T>(T entity, IValidator<T> validator) where T : Entity
        {
            var context = new ValidationContext<T>(entity);
            var result = validator.Validate(context);

            if (!result.IsValid)
            {
                foreach (var item in result.Errors)
                {
                    entity.notification.AddError(entity.GetType().Name, item.ErrorMessage);
                }
            }
        }
    }
}
