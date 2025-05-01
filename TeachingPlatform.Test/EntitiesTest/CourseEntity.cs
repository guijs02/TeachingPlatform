using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachingPlatform.Domain.Entities;
using TeachingPlatform.Domain.Factories;

namespace TeachingPlatform.UnitTests.EntitiesTest
{
    public class CourseEntityTest
    {
        [Fact]
        public void ShouldNotAcceptForValidation()
        {
            // Test case: Course name is empty
            var courseWithEmptyName = CourseFactory.Create(
                string.Empty,
                "Valid Description",
                Guid.NewGuid(),
                ["Lesson 1", "Lesson 2"],
                ["Module 1"]);

            var messagesForEmptyName = courseWithEmptyName.notification.GetMessages(nameof(Course));

            Assert.NotEmpty(messagesForEmptyName);
            Assert.Equal("Course: name must not be empty, ", messagesForEmptyName);

            // Test case: Course description is empty
            var courseWithEmptyDescription = CourseFactory.Create(
                "Valid Name",
                string.Empty,
                Guid.NewGuid(),
                ["Lesson 1", "Lesson 2"],
                ["Module 1"]);

            var messagesForEmptyDescription = courseWithEmptyDescription.notification.GetMessages(nameof(Course));

            Assert.NotEmpty(messagesForEmptyDescription);
            Assert.Equal("Course: description must not be empty, ", messagesForEmptyDescription);

            // Test case: Teacher ID is invalid
            var courseWithInvalidTeacherId = CourseFactory.Create(
                "Valid Name",
                "Valid Description",
                Guid.Empty,
                ["Lesson 1", "Lesson 2"],
                ["Module 1"]);

            var messagesForInvalidTeacherId = courseWithInvalidTeacherId.notification.GetMessages(nameof(Course));

            Assert.NotEmpty(messagesForInvalidTeacherId);
            Assert.Equal("Course: userId must be a valid GUID, ", messagesForInvalidTeacherId);
        }

        [Fact]
        public void ShouldAcceptForValidation()
        {
            var userId = Guid.NewGuid();
            // Test case: Valid course
            var validCourse = CourseFactory.Create(
                "Valid Name",
                "Valid Description",
                userId,
                ["Lesson 1", "Lesson 2"],
                ["Module 1"]);

            var messages = validCourse.notification.GetMessages(nameof(Course));

            Assert.Empty(messages);
            Assert.Equal("Valid Name", validCourse.Name);
            Assert.Equal("Valid Description", validCourse.Description);
            Assert.Equal(1, validCourse?.Modules.Count);
            Assert.Equal(userId, validCourse?.UserId);
        }
    }
}
