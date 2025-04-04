namespace TeachingPlatform.Domain.Entities
{
    public class Module : Entity
    {
        public Module(string name, Guid courseId) : base()
        {
            Name = name;
            CourseId = courseId;
            Lessons = new();
        }

        public string Name { get; private set; } = null!;
        public Guid CourseId { get; private set; }
        public List<Lesson> Lessons { get; private set; } = null!;

        public void AddLesson(Lesson lesson)
        {
            Lessons.Add(lesson);
        }

    }
}
