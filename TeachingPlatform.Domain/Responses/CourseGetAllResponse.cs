namespace TeachingPlatform.Domain.Responses
{
    public sealed record CourseGetAllResponse(Guid id, string name, string description, string progress)
    {
    }
}
