namespace TeachingPlatform.Domain.Entities
{
    public class Enrollment : Entity
    {
        public Enrollment(Guid studentId, Guid courseId, User student, Course course)
        {
            Course = course;
            Student = student;
            StudentId = studentId;
            CourseId = courseId;
            CreatedAt = DateTime.UtcNow;
        }
        public Enrollment(Guid studentId, Guid courseId)
        {
            StudentId = studentId;
            CourseId = courseId;
            CreatedAt = DateTime.UtcNow;
        }
     
        public Guid StudentId { get; private set; }
        public User Student { get; private set; } = null!;
        public Guid CourseId { get; private set; }
        public Course Course { get; private set; } = null!;
        public DateTime CreatedAt { get; private set; }

    }
}
