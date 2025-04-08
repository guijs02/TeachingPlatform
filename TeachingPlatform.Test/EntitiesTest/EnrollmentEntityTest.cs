using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachingPlatform.Domain.Entities;

namespace TeachingPlatform.UnitTests.EntitiesTest
{
    public class EnrollmentEntityTest
    {
        [Fact]
        public void ShouldNotAcceptForValidation()
        {
            var enroll = new Enrollment(Guid.NewGuid(), Guid.Empty);

            var messages = enroll.notification.GetMessages(nameof(Enrollment));

            Assert.NotEmpty(messages);
            Assert.Equal("Enrollment: courseId must be a valid GUID, ", messages);

            var enroll2 = new Enrollment(Guid.Empty, Guid.NewGuid());

            var messages2 = enroll2.notification.GetMessages(nameof(Enrollment));
            Assert.NotEmpty(messages2);
            Assert.Equal("Enrollment: studentId must be a valid GUID, ", messages2);

            var enroll3 = new Enrollment(Guid.Empty, Guid.Empty);
            var messages3 = enroll3.notification.GetMessages(nameof(Enrollment));

            Assert.NotEmpty(messages3);
            Assert.Equal("Enrollment: courseId must be a valid GUID, Enrollment: studentId must be a valid GUID, ", messages3);

        }

        [Fact]
        public void ShouldAcceptForValidation()
        {
            var user = new Enrollment(
                Guid.NewGuid(),
                Guid.NewGuid());

            var messages = user.notification.GetMessages(nameof(Enrollment));

            Assert.Empty(messages);
        }
    }
}
