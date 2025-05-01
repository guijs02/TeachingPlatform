using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachingPlatform.Domain.Entities;

namespace TeachingPlatform.Domain.Factories
{
    public static class CourseFactory
    {
        public static Course Create(string name,
                                    string description,
                                    Guid teacherId,
                                    IEnumerable<string> lessons,
                                    IEnumerable<string> modules)
        {
            var courseId = Guid.NewGuid();

            // Create modules with lessons
            var modulesEntity = CreateModules(modules, lessons, courseId);

            // Return the course with the created modules
            return new Course(courseId,name, description, teacherId, modulesEntity);
        }

        private static List<Module> CreateModules(IEnumerable<string> moduleNames, IEnumerable<string> lessonNames, Guid courseId)
        {
            return [.. moduleNames.Select(moduleName =>
            {
                var moduleId = Guid.NewGuid();
                var lessons = CreateLessons(lessonNames, moduleId);
                return new Module(moduleId, moduleName, courseId, lessons);
            })];
        }

        private static List<Lesson> CreateLessons(IEnumerable<string> lessonNames, Guid moduleId)
        {
            return lessonNames.Select(lessonName => new Lesson(Guid.NewGuid(),lessonName, moduleId)).ToList();
        }
    }
}
