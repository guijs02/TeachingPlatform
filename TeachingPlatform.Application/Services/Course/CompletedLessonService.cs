using System.Net;
using TeachingPlatform.Application.InputModels;
using TeachingPlatform.Application.Services.Interfaces;
using TeachingPlatform.Domain.Factories;
using TeachingPlatform.Domain.Repositories;

namespace TeachingPlatform.Application.Services.Course
{
    public class CompletedLessonService(ICourseRepository courseRepository) : ICompletedLessonService
    {
        private readonly ICourseRepository _courseRepository = courseRepository;

        public async Task<Response<bool>> FinishLessonAsync(FinishLessonInputModel lesson, Guid studentId)
        {
            if (!await _courseRepository.VerifyEnrollmentStudentActive(lesson.CourseId, studentId))
                return new Response<bool>(false, (int)HttpStatusCode.NotFound, "Enrollment not found for this student!");

            var result = await _courseRepository.FinishLessonAsync(lesson.CourseId, lesson.ModuleId, lesson.LessonId, studentId);

            if (!result)
                return new Response<bool>(false, (int)HttpStatusCode.NotFound, "Lesson not found");

            var course = await _courseRepository.GetCourseWithLessonCompleted(lesson.CourseId, studentId, lesson.ModuleId, lesson.LessonId);

            if(course is null)
                return new Response<bool>(false, (int)HttpStatusCode.NotFound);

            course.IncrementProgress();

            var isChanged = await _courseRepository.ChangeProgressAsync(course);

            return isChanged
                ? new Response<bool>(true)
                : new Response<bool>(false, (int)HttpStatusCode.InternalServerError, "Failed to update course progress");
        }
    }
}
