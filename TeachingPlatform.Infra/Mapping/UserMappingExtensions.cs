using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachingPlatform.Domain.Entities;
using TeachingPlatform.Domain.Models;

namespace TeachingPlatform.Infra.Mapping
{
    public static class UserMappingExtensions
    {
        public static User ToEntity(this UserModel model)
        {
            return new User
            {
                UserName = model?.UserName,
                Enrollments = model.Enrollments.ToEntity(),
                Password = model?.Password,
                TypeOfUser = (Domain.Entities.EUserRole)model.TypeOfUser,
            };
        }

        public static UserModel ToModel(this User model)
        {
            return new UserModel
            {
                UserName = model?.UserName,
                Enrollments = model.Enrollments.ToModel(),
                Password = model?.Password,
                TypeOfUser = (Domain.Models.EUserRole)model.TypeOfUser,
            };
        }
    }
}
