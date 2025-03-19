namespace TeachingPlatform.Application.InputModels
{
    public class EnrollmentInputModel
    {
        public Guid Id { get; set; }
        public Guid CourseId { get; set; }
        public Guid StudentId { get; set; }
    }
}
