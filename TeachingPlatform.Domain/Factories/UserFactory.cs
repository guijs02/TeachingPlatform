using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachingPlatform.Domain.Entities;

namespace TeachingPlatform.Domain.Factories
{
    public static class UserFactory
    {
        public static User Create(string userName, string password, EUserRole role)
        {
            return new User(Guid.NewGuid(), userName, password, role);
        }
    }
}
