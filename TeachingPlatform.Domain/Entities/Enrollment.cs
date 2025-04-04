namespace TeachingPlatform.Domain.Entities
{
    public class Enrollment : Entity
    {
        public Enrollment(Guid studentId, Guid courseId) : base()
        {
            StudentId = studentId;
            CourseId = courseId;
            CreatedAt = DateTime.UtcNow;
        }
     
        public Guid StudentId { get; private set; }
        public Guid CourseId { get; private set; }
        public DateTime CreatedAt { get; private set; }

    }
}
