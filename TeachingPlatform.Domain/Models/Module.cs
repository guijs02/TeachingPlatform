namespace TeachingPlatform.Domain.Models
{
    public class Module
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int LessonId { get; set; }
        public int CourseId { get; set; }
        public List<Lesson> Lessons { get; set; } = null!;
        public virtual Course Course { get; set; } = null!;
    }
}
