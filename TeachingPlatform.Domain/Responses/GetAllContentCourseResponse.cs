namespace TeachingPlatform.Domain.Responses
{
    public record GetAllContentCourseResponse(string name, IEnumerable<CourseModuleResponse> module)
    {
    }
    public record CourseModuleResponse(Guid id, string name, IEnumerable<CourseLessonResponse> lessons)
    {
    }
    public record CourseLessonResponse(string name, Guid id)
    {
    }
}