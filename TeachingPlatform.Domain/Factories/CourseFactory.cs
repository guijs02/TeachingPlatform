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
                                    IEnumerable<string> modules,
                                    IEnumerable<LessonDto> lessons)
        {
            var courseId = Guid.NewGuid();

            // Create modules with lessons
            var modulesEntity = CreateModules(modules, lessons, courseId);

            // Return the course with the created modules
            return new Course(courseId, name, description, teacherId, modulesEntity);
        }

        public static Course Create(Guid id,
                                   string name,
                                   string description,
                                   Guid teacherId,
                                   IEnumerable<string> modules,
                                   IEnumerable<LessonDto> lessons)
        {
            // Create modules with lessons
            var modulesEntity = CreateModules(modules, lessons, id);

            // Return the course with the created modules
            return new Course(id, name, description, teacherId, modulesEntity);
        }

        private static List<Module> CreateModules(IEnumerable<string> moduleNames, IEnumerable<LessonDto> lesson, Guid courseId)
        {
            return [.. moduleNames.Select(moduleName =>
            {
                var moduleId = Guid.NewGuid();
                var lessons = CreateLessons(lesson, moduleId);
                return new Module(moduleId, moduleName, courseId, lessons);
            })];
        }

        private static List<Lesson> CreateLessons(IEnumerable<LessonDto> lesson, Guid moduleId)
        {
            return lesson.Select(lesson => new Lesson(Guid.NewGuid(), lesson.name, moduleId, lesson.isCompleted)).ToList();
        }


    }
    public record LessonDto(string name, bool isCompleted)
    {
    }
}
