using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachingPlatform.Domain.Entities;
using TeachingPlatform.Domain.Factories;

namespace TeachingPlatform.UnitTests.EntitiesTest
{
    public class UserEntityTest
    {
        [Fact]
        public void ShouldNotAcceptForValidation()
        {
            var user = UserFactory.Create(
                "Test",
                string.Empty,
                EUserRole.TEACHER);

            var messages = user.notification.GetMessages(nameof(User));

            Assert.NotEmpty(messages);
            Assert.Equal("User: password must not be empty, ", messages);

            var user2 = UserFactory.Create(
                string.Empty,
                "Test",
                EUserRole.TEACHER);

            var messages2 = user2.notification.GetMessages(nameof(User));
            Assert.NotEmpty(messages2);
            Assert.Equal("User: username must not be empty, ", messages2);

            var user3 = UserFactory.Create(
                string.Empty,
                "Test",
                0);

            var messages3 = user3.notification.GetMessages(nameof(User));
            Assert.NotEmpty(messages3);
            Assert.Equal("User: username must not be empty, User: type of user is required, ", messages3);
        }

        [Fact]
        public void ShouldAcceptForValidation()
        {
            var user = UserFactory.Create("Test",
                "Test",
                EUserRole.TEACHER);

            var messages = user.notification.GetMessages(nameof(User));

            Assert.Empty(messages);
        }
    }
}
