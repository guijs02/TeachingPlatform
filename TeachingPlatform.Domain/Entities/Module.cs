namespace TeachingPlatform.Domain.Entities
{
    public class Module : Entity
    {
        public Module(string name, List<Lesson> lessons)
        {
            Name = name;
            Lessons = lessons;
        }
        public Module(Course course, Guid courseId, List<Lesson> lessons)
        {
            Course = course;
            CourseId = courseId;
            Lessons = lessons;
        }

        public string Name { get; private set; } = null!;
        public Guid CourseId { get; private set; }
        public List<Lesson> Lessons { get; private set; } = null!;
        public virtual Course Course { get; private set; } = null!;
    }
}
