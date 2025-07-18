using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachingPlatform.Domain.Entities;
using TeachingPlatform.Domain.Exceptions;
using TeachingPlatform.Domain.Factories;

namespace TeachingPlatform.UnitTests.EntitiesTest
{
    public class UserEntityTest
    {
        [Theory]
        [InlineData("Test", "", EUserRole.TEACHER)]
        [InlineData("", "Test", EUserRole.TEACHER)]
        [InlineData("", "Test", (EUserRole)0)]
        public void ShouldNotAcceptForValidation(string userName, string password, EUserRole role)
        {
            Assert.Throws<DomainException>(() => UserFactory.Create(userName, password, role));
        }

        [Fact]
        public void ShouldAcceptForValidation()
        {
            var user = UserFactory.Create("Test",
                "Test",
                EUserRole.TEACHER);

            var messages = user.Notification.GetMessages(nameof(User));

            Assert.Empty(messages);
        }
    }
}
