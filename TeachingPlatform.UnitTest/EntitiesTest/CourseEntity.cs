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
    public class CourseEntityTest
    {
        private static readonly List<string> ValidModules = ["Module 1", "Module 2"];
        private static readonly List<LessonDto> ValidLessons = [new("lesson1", false)];

        [Theory]
        [InlineData("", "Valid Description", "b2c1b437-6ae0-4a5e-9ad1-2cfd5939cafa")] // Nome inválido
        [InlineData("Valid Name", "", "b2c1b437-6ae0-4a5e-9ad1-2cfd5939cafa")]     // Descrição inválida
        [InlineData("Valid Name", "Valid Description", "00000000-0000-0000-0000-000000000000")] // TeacherId inválido
        public void ShouldThrowDomainExceptionForInvalidCourseInput(string name, string description, string teacherIdStr)
        {
            // Arrange
            var teacherId = Guid.Parse(teacherIdStr);

            // Act
            var act = () => CourseFactory.Create(name, description, teacherId, ValidModules, ValidLessons);

            // Assert
            Assert.Throws<DomainException>(act);
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
                ["Module 1"],
                [new LessonDto("lesson1", false)]);

            var messages = validCourse.Notification.GetMessages(nameof(Course));

            Assert.Empty(messages);
            Assert.Equal("Valid Name", validCourse.Name);
            Assert.Equal("Valid Description", validCourse.Description);
            Assert.Equal(1, validCourse?.Modules.Count);
            Assert.Equal(userId, validCourse?.UserId);
        }
    }
}
