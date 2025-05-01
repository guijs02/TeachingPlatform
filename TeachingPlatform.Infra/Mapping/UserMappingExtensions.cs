using TeachingPlatform.Domain.Entities;
using TeachingPlatform.Domain.Factories;
using TeachingPlatform.Infra.Models;

namespace TeachingPlatform.Infra.Mapping
{
    public static class UserMappingExtensions
    {
        public static User ToEntity(this UserModel model)
        {
            return UserFactory.Create(
                model?.UserName,
                model.Password,
                (Domain.Entities.EUserRole)model.TypeOfUser);
        }

        public static UserModel ToModel(this User model)
        {
            return new UserModel
            {
                UserName = model?.UserName,
                Enrollments = model.Enrollments.ToModel(),
                Password = model?.Password,
                TypeOfUser = (Models.EUserRole)model.TypeOfUser,
            };
        }
    }
}
