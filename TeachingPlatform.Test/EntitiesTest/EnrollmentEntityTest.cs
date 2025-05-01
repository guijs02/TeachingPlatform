using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachingPlatform.Domain.Entities;
using TeachingPlatform.Domain.Factories;

namespace TeachingPlatform.UnitTests.EntitiesTest
{
    public class EnrollmentEntityTest
    {
        [Fact]
        public void ShouldNotAcceptForValidation()
        {
            var enroll = EnrollmentFactory.Create(Guid.NewGuid(), Guid.Empty);

            var messages = enroll.notification.GetMessages(nameof(Enrollment));

            Assert.NotEmpty(messages);
            Assert.Equal("Enrollment: courseId must be a valid GUID, ", messages);

            var enroll2 = EnrollmentFactory.Create(Guid.Empty, Guid.NewGuid());

            var messages2 = enroll2.notification.GetMessages(nameof(Enrollment));
            Assert.NotEmpty(messages2);
            Assert.Equal("Enrollment: studentId must be a valid GUID, ", messages2);

            var enroll3 = EnrollmentFactory.Create(Guid.Empty, Guid.Empty);
            var messages3 = enroll3.notification.GetMessages(nameof(Enrollment));

            Assert.NotEmpty(messages3);
            Assert.Equal("Enrollment: courseId must be a valid GUID, Enrollment: studentId must be a valid GUID, ", messages3);
        }

        [Fact]
        public void ShouldAcceptForValidation()
        {
            var user = EnrollmentFactory.Create(
                Guid.NewGuid(),
                Guid.NewGuid());

            var messages = user.notification.GetMessages(nameof(Enrollment));

            Assert.Empty(messages);
        }
    }
}
