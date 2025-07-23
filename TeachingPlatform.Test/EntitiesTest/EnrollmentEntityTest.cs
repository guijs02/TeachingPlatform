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
    public class EnrollmentEntityTest
    {
        private const string EMPTY = "00000000-0000-0000-0000-000000000000";
        private const string VALID = "d290f1ee-6c54-4b01-90e6-d701748f0851";

        [Theory]
        [InlineData(EMPTY, VALID)]
        [InlineData(VALID, EMPTY)]
        [InlineData(EMPTY, EMPTY)]
        public void ShouldNotAcceptForValidation(string studentIdString, string courseIdString)
        {
            Assert.Throws<DomainException>(() => EnrollmentFactory.Create(Guid.Parse(studentIdString), Guid.Parse(courseIdString)));
        }

        [Fact]
        public void ShouldAcceptForValidation()
        {
            var user = EnrollmentFactory.Create(
                Guid.NewGuid(),
                Guid.NewGuid());

            var messages = user.Notification.GetMessages(nameof(Enrollment));

            Assert.Empty(messages);
        }
    }
}
